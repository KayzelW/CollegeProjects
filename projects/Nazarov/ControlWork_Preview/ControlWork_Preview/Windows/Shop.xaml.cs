using ControlWork_Preview.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using System.Threading;

namespace ControlWork_Preview.Windows;
/*
        root
из текстового файла берем данные о списке товаров в магазине 
Например:
    1 хлеб еда шт 52 руб
    2 молоко еда л 75 руб
    3 мыло хозтовар шт 60 руб
Эти данные из файла загружаются во внутреннюю таблицу (в интерфейсе приложения). 
Также в программе должна быть кнопка с сортировкой по цене и выгрузкой в эксель. 
В экселе также после выгрузки должна появиться гистограмма.
*/

/// <summary>
/// Логика взаимодействия для Shop.xaml
/// </summary>
public partial class Shop : Window
{
    private string resourcePath;
    private List<Good> goods = new List<Good>();
    public AppDbContext dbContext;

    public Shop()
    {
        InitializeComponent();
        Closing += Shop_Closing;
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
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using var Excel = new ExcelPackage(resourcePath + @"\Excel.xlsx");

        var worksheet = Excel.Workbook.Worksheets.Where(x => x.Name == "Shop").FirstOrDefault();
        if (worksheet == null)
        {
            Excel.Workbook.Worksheets.Add("Shop");
            worksheet = Excel.Workbook.Worksheets.Where(x => x.Name == "Shop").FirstOrDefault();
        }

        worksheet!.Cells.Clear();
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

        await Excel.SaveAsAsync(Excel.File);
    }

    private void DB_UploadBtn_Click(object sender, RoutedEventArgs e)
    {
        dbContext.Goods.AttachRange(goods);
    }
}
