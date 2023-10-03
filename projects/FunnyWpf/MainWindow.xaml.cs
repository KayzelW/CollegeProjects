using FunnyWpf.Rootes;
using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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
using FunnyWpf.Rootes;

namespace FunnyWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void superButton(object sender, RoutedEventArgs e)
        {
            if (button.Content != "funny green button")
            {
                textTarget.Text = textBox.Text;
                textBox.Text = "Super text from the super button";
                button.Background = new SolidColorBrush(Colors.Green);
                button.Content = "funny green button";
            }
            else if (button.Content != "Bad button")
            {
                button.Content = "Bad button";
                button.Visibility = Visibility.Hidden;
                square.Visibility = Visibility.Visible;
                cube.Visibility = Visibility.Visible;
                textBox.Text = "1";
                textTarget.Text = "Don't use char in intBox(";
            } 
            else if (button.Content == "Bad button")
            {
                FunnyFunctions.BadResult(mainWindow);
            }
        }

        private void square_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                textTarget.Text = FunnyFunctions.squareButton(textBox.Text);
            }
            catch
            {
                button.Visibility = Visibility.Visible;
                square.Visibility = Visibility.Hidden;
                cube.Visibility = Visibility.Hidden;
            }
        }

        private void cube_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                textTarget.Text = FunnyFunctions.cubeButton(textBox.Text);
            }
            catch
            {
                button.Visibility = Visibility.Visible;
                square.Visibility = Visibility.Hidden;
                cube.Visibility = Visibility.Hidden;
            }
        }
    }
}
