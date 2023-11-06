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
using OfficeOpenXml.FormulaParsing.Excel.Functions.Finance.Implementations;

namespace MDK01._02_LR3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private static string resourcePath = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf(@"\bin"));
    public Table tableWindow { get; set; } = new Table();
    public List<GraphicResult> data { get; set; } = new List<GraphicResult>();
    private Calculate Calculate = new Calculate();
    public MainWindow()
    {
        InitializeComponent();
        imageField.Source = new BitmapImage(new Uri(resourcePath + @"\formula.png", UriKind.Absolute));
        DataContext = this;
        Closing += MainWindow_Closing;
        Calculate.mainWindow = this;
    }

    private void MainWindow_Closing(object? sender, CancelEventArgs e)
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
        if (data.Count == 0)
        {
            tableWindow.dataGrid.ItemsSource = data;
            tableWindow.Show();
        }

        Calculate.Execute();
        if (data.Count != 0)
        {
            tableWindow.dataGrid.Items.Refresh();
        }
    }

    public struct GraphicResult
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
            if (!Calculate.Execute())
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
