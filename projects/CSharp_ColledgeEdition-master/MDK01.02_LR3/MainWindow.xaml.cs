using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
using System.IO;

namespace MDK01._02_LR3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private static string resourcePath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf(@"\bin"));
    private Table tableWindow { get; set; } = new Table();
    private List<GraphicResult> data { get; set; } = new List<GraphicResult>();
    public MainWindow()
    {
        InitializeComponent();
        imageField.Source = new BitmapImage(new Uri(resourcePath + @"\formula.png", UriKind.Absolute));
        DataContext = this;
        Closing += MainWindow_Closing;
    }

    private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        tableWindow.Close();
        Environment.Exit(0);
    }

    private void eraseButton_Click(object sender, RoutedEventArgs e)
    {
        Erase();
        errorView.Visibility = Visibility.Hidden;
    }

    private void executeButton_Click(object sender, RoutedEventArgs e)
    {
        Calculate();
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

    private bool Calculate()
    {
        if (int.TryParse(x1TextBox.Text, out var x1)) { }
        else { Erase("x1 не целое число"); return false; }
        if (int.TryParse(x2TextBox.Text, out var x2)) { }
        else { Erase("x2 не целое число"); return false; }
        if (int.TryParse(x2TextBox.Text, out var a)) { }
        else { Erase("a не целое число"); return false; }
        if (int.TryParse(x2TextBox.Text, out var b)) { }
        else { Erase("b не целое число"); return false; }
        if (int.TryParse(dxTextBox.Text, out var dx)) { }
        else { Erase("dx не целое число"); return false; }


        if (x1 == 0 || x2 == 0 || (x1 > x2) || (x1 == x2))
        {
            Erase("x1 и x2 не диапазонон с длиной > 0");
            return false;
        }

        //if (x1 <= 0 && x2 >= 0)
        //{
        //    Erase("Диапазон не должен включать 0");
        //    return false;
        //}

        if (b == 0)
        {
            Erase("b = 0");
            return false;
        }

        if (dx < 0)
        {
            Erase("dx должно быть >= 0");
            return false;
        }

        if (dx >= x2 - x1)
        {
            Erase("dx больше отрезка");
            return false;
        }

        data = new List<GraphicResult>();
        for (int i = x1; i <= x2; i += dx == 0 ? dx : 1)
        {
            if (i != 0)
            {
                data.Add(new GraphicResult(
                    Math.Abs(Math.Pow(2 * a - 7.5 * i, 3)) + Math.Pow(Math.E, ((2 * b) / i) - a / (2 * b))
                , i));
            }
            else
            {
                data.Add(new GraphicResult(0, i));
            }
        }
        return true;
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

    private void ExportButton_Click(object sender, RoutedEventArgs e)
    {
        ThreadPool.QueueUserWorkItem(ExcelUpload);
    }

    private async void ExcelUpload(object? _)
    {
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        using var Excel = new ExcelPackage(resourcePath + @"\Excel.xlsx");
        this.Dispatcher.Invoke(() =>
        {
            if (!Calculate())
            {
                MessageBox.Show("Неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var worksheet = Excel.Workbook.Worksheets.FirstOrDefault();

            worksheet?.Cells.Clear();

            worksheet.Cells[$"C1"].Value = "x1";
            worksheet.Cells[$"D1"].Value = "x2";
            worksheet.Cells[$"E1"].Value = "a";
            worksheet.Cells[$"F1"].Value = "b";
            worksheet.Cells[$"G1"].Value = "dx";


            worksheet.Cells[$"C2"].Value = x1TextBox.Text;
            worksheet.Cells[$"D2"].Value = x2TextBox.Text;
            worksheet.Cells[$"E2"].Value = aTextBox.Text;
            worksheet.Cells[$"F2"].Value = aTextBox.Text;
            worksheet.Cells[$"G2"].Value = aTextBox.Text;

            worksheet.Cells[$"A1"].Value = "X";
            worksheet.Cells[$"B1"].Value = "ANSWER";
            int row = 1;

            foreach (var item in data)
            {
                row++;
                worksheet.Cells[$"A{row}"].Value = item.x;
                worksheet.Cells[$"B{row}"].Value = item.value;
            }
        });
        await Excel.SaveAsAsync(Excel.File);
    }
}
