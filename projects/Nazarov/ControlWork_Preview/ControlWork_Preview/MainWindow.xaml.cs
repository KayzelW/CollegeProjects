using ControlWork_Preview.Classes;
using Microsoft.EntityFrameworkCore;
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

namespace ControlWork_Preview;

/// <summary>
/// Логика взаимодействия для MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string resourcePath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf(@"\bin")) + @"\Resources";
    private AppDbContext dbContext;
    public MainWindow()
    {
        InitializeComponent();
        InitializeDbContext();
    }
    private void InitializeDbContext()
    {
        var databasePath = System.IO.Path.Combine(Environment.CurrentDirectory, "MyDatabase.db"); //Путь к БД
        var connectionString = $"Data Source={databasePath}"; // Строка подключения
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>(); // Конфигуратор БД
        optionsBuilder.UseSqlite(connectionString); // Использовать эту строку подключения
        
        dbContext = new AppDbContext(optionsBuilder.Options); // создание объекта БД
        dbContext.Database.EnsureCreated(); // Файл точно есть?
    }

}
