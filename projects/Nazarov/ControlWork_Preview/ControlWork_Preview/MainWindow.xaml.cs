using ControlWork_Preview.Classes;
using ControlWork_Preview.Windows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
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
    protected AppDbContext dbContext;
    public int status { get; set; }

    public Shop Shop;
    public Vendings Vendings;

    //private Thread check;

    public MainWindow()
    {
        status = 1;
        InitializeComponent();
        InitializeDbContext();
        //check = new Thread(StatusCheck);
        //check.Start();
        Closing += MainWindow_Closing;
        this.Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        dbContext.SaveChanges();
        Shop?.Close();
        Vendings?.Close();
        Environment.Exit(0);
    }

    private void InitializeDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>(); // Конфигуратор БД
        optionsBuilder.UseSqlite(
                $"Data Source={System.IO.Path.Combine(Environment.CurrentDirectory, "MyDatabase.db")}"
            ); // Использовать эту строку подключения

        dbContext = new AppDbContext(optionsBuilder.Options); // создание объекта БД
        dbContext.Database.EnsureCreated(); // Файл точно есть?
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var login = loginText.Text.Trim();
        var password = passwordText.Password.Trim();
        switch (login, password)
        {
            case ("root", "root"):
                Shop ??= new Shop(resourcePath, ref dbContext);
                Shop.Owner = this;
                this.Shop.Show();
                this.Hide();
                ClearText();
                break;
            case ("user", "user"):
                Vendings ??= new Vendings(resourcePath, ref dbContext);
                Vendings.Owner = this;
                this.Vendings.Show();
                this.Hide();
                ClearText();
                break;
            default:
                status = 1;
                ClearText();
                break;
        }
    }

    private void ClearText()
    {
        loginText.Text = string.Empty;
        passwordText.Password = string.Empty;
    }

    //private CancellationTokenSource interruption = new();
    /*
    async private void StatusCheck()
    {
        while (!interruption.IsCancellationRequested)
        {
            this.Dispatcher.Invoke(() =>
            {
                switch (this.status)
                {
                    case 0:
                        if (this.Visibility == Visibility.Visible)
                            AuthWindow.Hide();
                        break;
                    case 1:
                        if (this.Visibility == Visibility.Hidden)
                            this.AuthWindow.Show();
                        break;
                }
            });

            try
            {
                await Task.Delay(1000, interruption.Token);
            }
            catch (Exception ex) { }
        }
    }
    */
}
