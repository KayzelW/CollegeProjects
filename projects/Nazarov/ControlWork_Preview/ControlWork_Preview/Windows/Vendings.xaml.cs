﻿using ControlWork_Preview.Classes;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Threading;

namespace ControlWork_Preview.Windows;

/*
            user
Работа с бд, которая будет учитывать марку автомобиля, год производства, цвет, страну производителя. 
Реализовать выгрузку данных из базы в эксель, с учетом возможности выбора разных цветов.
 */

/// <summary>
/// Логика взаимодействия для Vendings.xaml
/// </summary>
public partial class Vendings : Window
{
    private string? resourcePath;
    public ObservableCollection<Vending> Machines = new();
    public AppDbContext? dbContext;

    public Vendings()
    {
        InitializeComponent();
        DataContext = this;
        Closing += Vendings_Closing;
        dataGrid.MouseDoubleClick += DataGrid_MouseDoubleClick;
    }

    private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {   
        if (dataGrid.SelectedItem is Vending currentMachine)
        {
            var editMachine = new AddMachine();
            editMachine.Owner = this;

            editMachine.Id.Text = currentMachine.Id.ToString();
            editMachine.Model.Text = currentMachine.Model;
            editMachine.Year.Text = currentMachine.Year;
            editMachine.Color.Text = currentMachine.Color;
            editMachine.CountryPerformer.Text = currentMachine.CountryPerformer;

            editMachine.ShowDialog();
            currentMachine.Id = int.Parse(editMachine.Id.Text);
            currentMachine.Model = editMachine.Model.Text;
            currentMachine.Year = editMachine.Year.Text;
            currentMachine.Color = editMachine.Color.Text;
            currentMachine.CountryPerformer = editMachine.CountryPerformer.Text;

            currentMachine.Dirty();
            dbContext.SaveChanges();
        }
    }

    private void Vendings_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        this.Hide();
        this.Owner.Show();
    }

    public Vendings(string resourcePath, ref AppDbContext dbContext) : this()
    {
        (this.resourcePath, this.dbContext) = (resourcePath, dbContext);
        dbContext.Vendings.ToList().ForEach(v =>
        {
            Machines.Add(v);
        });
        dbContext.AttachRange(Machines);
        dataGrid.ItemsSource = Machines;
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        var newMachine = new AddMachine();
        newMachine.Owner = this;
        newMachine.ShowDialog();

        Machines.Add(new Vending(
                    int.Parse(newMachine.Id.Text), newMachine.Model.Text, newMachine.Year.Text, newMachine.Color.Text, newMachine.CountryPerformer.Text
        ));

        dbContext!.SaveChanges();
    }

    private void Excel_Click(object sender, RoutedEventArgs e)
    {
        ThreadPool.QueueUserWorkItem(ExcelUpload);
    }

    private async void ExcelUpload(object? _)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using var Excel = new ExcelPackage(resourcePath + @"\Excel.xlsx");
        this.Dispatcher.Invoke(() =>
        {
            var worksheet = Excel.Workbook.Worksheets.Where(x => x.Name == "Machines").FirstOrDefault();
            if (worksheet == null)
            {
                Excel.Workbook.Worksheets.Add("Machines");
                worksheet = Excel.Workbook.Worksheets.Where(x => x.Name == "Machines").FirstOrDefault();
            }

            worksheet?.Cells.Clear();

            worksheet.Cells[$"A1"].Value = "ID";
            worksheet.Cells[$"B1"].Value = "Марка";
            worksheet.Cells[$"C1"].Value = "Год выпуска";
            worksheet.Cells[$"D1"].Value = "Цвет";
            worksheet.Cells[$"E1"].Value = "Страна исполнителя";

            int row = 1;
            foreach (var item in Machines)
            {
                row++;
                worksheet.Cells[$"A{row}"].Value = item.Id.ToString();
                worksheet.Cells[$"B{row}"].Value = item.Model;
                worksheet.Cells[$"C{row}"].Value = item.Year;
                worksheet.Cells[$"D{row}"].Value = item.Color;
                worksheet.Cells[$"E{row}"].Value = item.CountryPerformer ;
            }
        });
        await Excel.SaveAsAsync(Excel.File);
    }
}