using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace DatabaseView;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private AppDbContext dbContext;
    public ObservableCollection<User> Users { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        InitializeDbContext();
        LoadUsers();
        DataContext = this;
        usersListView.MouseDoubleClick += UsersListView_MouseDoubleClick;
    }


    private void InitializeDbContext()
    {
        var databasePath = Path.Combine(Environment.CurrentDirectory, "MyDatabase.db"); //Путь к БД
        var connectionString = $"Data Source={databasePath}"; // Строка подключения
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>(); // Конфигуратор БД
        optionsBuilder.UseSqlite(connectionString); // Использовать эту строку подключения

        dbContext = new AppDbContext(optionsBuilder.Options); // создание объекта БД
        dbContext.Database.EnsureCreated(); // Файл точно есть?
    }

    private void LoadUsers()
    {
        if (Users == null)
        {
            Users = new ObservableCollection<User>(dbContext.Users.ToList());
        }
        else
        {
            Users.Clear();
            foreach (var user in dbContext.Users)
            {
                Users.Add(user);
            }
        }
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        var newCustomer = new User { Name = "newClient", Email = "newClientEMAIL@gmail.com" };
        dbContext.Users.Add(newCustomer);
        dbContext.SaveChanges();
        Users.Add(newCustomer);
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        LoadUsers();
    }

    private void UsersListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (usersListView.SelectedItem is User selectedCustomer)
        {
            UpdateRecord editWindow = new UpdateRecord();
            editWindow.Owner = this;
            editWindow.nameTextBox.Text = selectedCustomer.Name;
            editWindow.emailTextBox.Text = selectedCustomer.Email;
            editWindow.ShowDialog();

            selectedCustomer.Name = editWindow.nameTextBox.Text;
            selectedCustomer.Email = editWindow.emailTextBox.Text;
            selectedCustomer.Dirty();
            dbContext.SaveChanges();

            // Обновление ListView после закрытия окна редактирования
            LoadUsers();
        }
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        var users = usersListView.SelectedItems.Cast<User>().ToList();
        foreach (var user in users)
        {
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            Users.Remove(user);
        }
    }
}
