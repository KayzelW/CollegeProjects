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
using System.Windows.Shapes;

namespace TwoWindows
{
    /// <summary>
    /// Логика взаимодействия для SupWindow.xaml
    /// </summary>
    public partial class SupWindow : Window
    {
        List<User> users = new List<User>();
        public Random rnd = new Random();
        public SupWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(rnd.Next());
        }
        private async void Calculate_Click(object sender, RoutedEventArgs e)
        {
            var str = textBox.Text;
            var password = passwordBox.Password;
            var email = emailBox.Text;
            if (email.IndexOf('@') == -1)
            {
                emailBox.Text = string.Empty;
                MessageBox.Show("Кажется, это не адрес?", "Ошибка");
                return;
            }
            users.Add(new User(str, email,  password));
            
        }
    }
}
