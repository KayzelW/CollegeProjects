using Cancelary.ContentClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class Menu : Form
    {
        public AppDbContext dbContext { get; set; }
        private string executePath { get; set; }
        private string localPath { get; set; }
        public Menu()
        {
            executePath = Environment.CurrentDirectory;
            localPath = executePath.Substring(0, executePath.IndexOf(@"\bin"));

            var databasePath = Path.Combine(localPath, "MyDatabase.db"); //Путь к БД
            var connectionString = $"Data Source={databasePath}"; // Строка подключения
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>(); // Конфигуратор БД
            optionsBuilder.UseSqlite(connectionString); // Использовать эту строку подключения
            dbContext = new AppDbContext(optionsBuilder.Options); // создание объекта БД
            dbContext.Database.EnsureCreated();

            InitializeComponent();
        }

        private void DBRedescribeBTN_Click(object sender, EventArgs e)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            var docs = Document.ReadFromFile(localPath);
            var deps = Department.ReadFromFile(localPath);
            var docTypes = DocType.ReadFromFile(localPath);

            docTypes.ForEach(x => dbContext.DocTypes.Add(x));
            docs.ForEach(x => dbContext.Documents.Add(x));
            deps.ForEach(x => dbContext.Departments.Add(x));

            dbContext.SaveChanges();
        }

        private void WriteBTN_Click(object sender, EventArgs e)
        {
            var docs = dbContext.Documents.ToList();
            var deps = dbContext.Departments.ToList();
            var docTypes = dbContext.DocTypes.ToList();

            var inputFile = new FileInfo($"{localPath}" + @"\ToRead\in.txt");
            dataGridView.Columns.Add("Id", "Код отдела");
            dataGridView.Columns.Add("TypeId", "Код документа");
            dataGridView.Columns.Add("nameDoc", "Название документа");
            dataGridView.Columns.Add("dateDoc", "Дата регистрации");

            foreach (var line in File.ReadAllLinesAsync(inputFile.FullName).Result)
            {
                var str = line.Split();
                var result = docs.Where(x => (x.Sender == int.Parse(str[0])));  //&& (x.DocTypeId == int.Parse(str[1])) - вырезано из-за малых входных данных
                
                foreach (var item in result)
                {
                    dataGridView.Rows.Add(item.Id, item.Number, item.Name, item.RegistrationTime.ToShortDateString());
                }
            }
            Width = 730;
            CenterToScreen();
            dataGridView.Visible = true;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void About_Click(object sender, EventArgs e)
        {
            var aboutWindow = new AboutBox1();
            aboutWindow.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
