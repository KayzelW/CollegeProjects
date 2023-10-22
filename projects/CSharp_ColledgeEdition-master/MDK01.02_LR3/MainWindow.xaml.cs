using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MDK01._02_LR3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Table tableWindow { get; set; } = new Table();
    private List<GraphicResult> data { get; set; } = new List<GraphicResult>();
    public MainWindow()
    {
        InitializeComponent();
        Closing += MainWindow_Closing;
    }

    private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        tableWindow.Close();
    }

    private void eraseButton_Click(object sender, RoutedEventArgs e)
    {
        Erase();
        errorView.Visibility = Visibility.Hidden;
    }

    private void executeButton_Click(object sender, RoutedEventArgs e)
    {
        if (int.TryParse(x1TextBox.Text, out var x1)) { }
        else { Erase("x1 не целое число"); return; }
        if (int.TryParse(x2TextBox.Text, out var x2)) { }
        else { Erase("x2 не целое число"); return; }
        if (int.TryParse(x2TextBox.Text, out var a)) { }
        else { Erase("a не целое число"); return; }
        if (int.TryParse(x2TextBox.Text, out var b)) { }
        else { Erase("b не целое число"); return; }
        if (int.TryParse(dxTextBox.Text, out var dx)) { }
        else { Erase("dx не целое число"); return; }


        if (x1 == 0 || x2 == 0 || (x1 > x2) || (x1 == x2))
        {
            Erase("x1 и x2 не диапазонон с длиной > 0");
            return;
        }

        if (x1 <= 0 && x2 >= 0)
        {
            Erase("Диапазон не должен включать 0");
            return;
        }

        if (b == 0)
        {
            Erase("b = 0");
            return;
        }

        if (dx < 0)
        {
            Erase("dx должно быть >= 0");
            return;
        }

        if (dx >= x2 - x1)
        {
            Erase("dx больше отрезка");
            return;
        }


        data.Clear();
        for (int i = x1; i <= x2; i += dx == 0 ? dx : 1)
        {
            data.Add(new GraphicResult(
                    Math.Abs(Math.Pow(2 * a - 7.5 * i, 3)) + Math.Pow(Math.E, ((2 * b) / i) - a / (2 * b))
                , i));
        }

        if (data.Count != 0)
        {
            tableWindow.dataGrid.ItemsSource = data;
            tableWindow.dataGrid.Items.Refresh();
            tableWindow.Show();
        }
    }

    private struct GraphicResult
    {
        public double value { get; private set; }
        public int x { get; private set; }
        public GraphicResult(double input, int i) => (this.value, this.x) = (Math.Round(input, 2), i);
    }

    private void aboutButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Это программа для вычисления заданной формулы.");
    }

    private void Erase()
    {
        x1TextBox.Text = string.Empty;
        x2TextBox.Text = string.Empty;
        aTextBox.Text = string.Empty;
        bTextBox.Text = string.Empty;
        dxTextBox.Text = string.Empty;
    }

    private void Erase(string Error)
    {
        Erase();
        errorView.Visibility = Visibility.Visible;
        errorTextBlock.Text = Error;
    }
}
