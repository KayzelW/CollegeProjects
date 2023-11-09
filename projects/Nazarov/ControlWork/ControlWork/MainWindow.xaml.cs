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
using ControlWork.Windows;
using ControlWork.Classes;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;


namespace ControlWork;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string resourcePath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf(@"\bin")) + @"\Resources";
    protected AppDbContext dbContext;
    public int status { get; set; }

    public Shop Shop;
    public Vendings Vendings;

    public MainWindow()
    {
        status = 1;
        InitializeComponent();
        InitializeDbContext();
        Closing += MainWindow_Closing;
        this.Loaded += MainWindow_Loaded;

        passwordText.KeyDown += Text_KeyDown;
        loginText.KeyDown += Text_KeyDown;
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }

    private void Text_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            Auth();
        }
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
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite(
                $"Data Source={System.IO.Path.Combine(Environment.CurrentDirectory, "MyDatabase.db")}"
            );
        dbContext = new AppDbContext(optionsBuilder.Options);
        dbContext.Database.EnsureCreated();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Auth();
    }

    private void Auth()
    {
        var login = loginText.Text.Trim();
        var password = passwordText.Password.Trim();
        switch (login, password)
        {
            case ("root", "root"):
                Shop = new Shop(resourcePath, ref dbContext);
                Shop.Owner = this;
                Shop.Show();
                this.Hide();
                ClearText();
                break;
            case ("user", "user"):
                Vendings = new Vendings(resourcePath, ref dbContext);
                Vendings.Owner = this;
                Vendings.Show();
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
}
