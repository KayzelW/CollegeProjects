using Microsoft.EntityFrameworkCore;
using sorted_books.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using sorted_books;
using Visual.Console;

namespace Visual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static AppDbContext dbContext { get; set; } = Program.dbContext!;
        private static string executePath { get; set; } = Environment.CurrentDirectory;
        private static string localPath { get; set; } = executePath.Substring(0, executePath.IndexOf(@"\bin"));
        public MainWindow()
        {
            var databasePath = localPath + "MyDatabase.db"; //Путь к БД
            var connectionString = $"Data Source={databasePath}"; // Строка подключения
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>(); // Конфигуратор БД
            optionsBuilder.UseSqlite(connectionString); // Использовать эту строку подключения

            dbContext = new AppDbContext(optionsBuilder.Options); // создание объекта БД
            dbContext.Database.EnsureCreated();

            var data = dbContext.Books.ToList().ConvertAll(x => x.ToString());
            data.ForEach(x => textBox.Text += x + '\n');

            ConsoleWindow Console = new ConsoleWindow();
            Console.Show();

            data.ForEach(x => Console.WriteLine(x));

            InitializeComponent();
        }
    }
}
