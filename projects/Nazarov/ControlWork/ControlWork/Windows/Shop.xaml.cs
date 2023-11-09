using ControlWork.Classes;
using LiveCharts.Wpf;
using LiveCharts;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;
using System.IO;

namespace ControlWork.Windows;

/*
            root
из текстового файла берем данные о списке товаров в магазине    
1 хлеб еда шт 52 руб
2 молоко еда л 75 руб
3 мыло хозтовар шт 60 руб
*/
public partial class Shop : Window
{
    private string? resourcePath;
    private List<Good> goods = new List<Good>();
    public AppDbContext dbContext;

    public Shop()
    {
        InitializeComponent();
        Closing += Shop_Closing;
        DataContext = this;
    }

    private void Shop_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        this.Hide();
        this.Owner.Show();
    }

    public Shop(string resourcePath, ref AppDbContext dbContext) : this()
    {
        (this.resourcePath, this.dbContext) = (resourcePath, dbContext);
        MainFunc();
    }

    private void MainFunc()
    {
        goods = ReadFromFile().ToList();
        dataGrid.ItemsSource = goods;
        DrawHistogram();
    }

    private IEnumerable<Good> ReadFromFile()
    {
        var path = resourcePath + @"\goods.txt";
        var lines = File.ReadAllLines(path);

        foreach (var line in lines)
        {
            yield return new Good(line);
        }
    }

    private void ExcelBtn_Click(object sender, RoutedEventArgs e)
    {
        ThreadPool.QueueUserWorkItem(ExcelUpload);
    }

    private async void ExcelUpload(object? _)
    {
        using var Excel = new ExcelPackage(resourcePath + @"\Excel.xlsx");

        var worksheet = Excel.Workbook.Worksheets.Where(x => x.Name == "Shop").FirstOrDefault()
                        ?? Excel.Workbook.Worksheets.Add("Shop");
        worksheet.Cells.Clear();
        worksheet.Drawings.Clear();

        worksheet.Cells[$"A1"].Value = "Название";
        worksheet.Cells[$"B1"].Value = "Категория";
        worksheet.Cells[$"C1"].Value = "Стоимость";
        int row = 1;
        foreach (var item in goods)
        {
            row++;
            worksheet.Cells[$"A{row}"].Value = item.Name;
            worksheet.Cells[$"B{row}"].Value = item.Category;
            worksheet.Cells[$"C{row}"].Value = item.Price;
        }

        #region Charts
        var chart = worksheet.Drawings.AddChart("Гистограмма", eChartType.ColumnClustered);
        chart.Series.Add(
            worksheet.Cells[$"C2:C{row}"], //Ось X
            worksheet.Cells[$"A2:A{row}"]  //Ось Y
            );

        chart.Title.Text = "Гистограмма";
        chart.XAxis.Title.Text = "Категория";
        chart.YAxis.Title.Text = "Стоимость";

        chart.SetPosition(5, 200);
        chart.SetSize(400, 400);
        #endregion

        await Excel.SaveAsAsync(Excel.File);
        MessageBox.Show("Done", "Статус выгрузки в Excel", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void DB_UploadBtn_Click(object sender, RoutedEventArgs e)
    {
        dbContext.Goods.AttachRange(goods);
    }

    private void Chart_Click(object sender, RoutedEventArgs e)
    {
        DrawHistogram();
    }

    private void DrawHistogram()
    {
        chartsComponent.Series.Clear();
        chartsComponent.AxisX.Clear();
        chartsComponent.AxisY.Clear();

        // Создание экземпляра SeriesCollection
        var seriesCollection = new SeriesCollection
        {
            new ColumnSeries
            {
                Title = "Цена:",
                Values = new ChartValues<double> (goods.Select(x => (double)x.Price)),
            }
        };

        // Настройка осей
        // X
        chartsComponent.AxisX.Add(new Axis
        {
            Labels = goods.Select(x => x.Name).ToArray()
        });
        // Y
        chartsComponent.AxisY.Add(new Axis
        {
            Title = "Цены"
        });

        // Установка созданной SeriesCollection в элемент управления
        chartsComponent.Series = seriesCollection;
    }
}
