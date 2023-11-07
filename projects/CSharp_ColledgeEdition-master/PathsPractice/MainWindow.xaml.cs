using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PathsPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileInfo dataPath = new FileInfo(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("bin")) + @"Resources\book.xlsx");

        public MainWindow()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            InitializeComponent();
        }

        private List<Point> GetData(string path, string range="A2:B17")
        {
            if (range == "") { range = "A2:B170"; }
            var points = new List<Point>();
            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                var sheet = package.Workbook.Worksheets[0];
                var excelRange = sheet.Cells[range].ToList().ConvertAll(x => double.Parse(x.Value.ToString()));
                excelRange.ForEach(x => label.Content += $" {x}");

                //excelRange.ForEach(x => test.Text += ($" {x}"));

                for (int i = 0; i < excelRange.Count; i+=2)
                {
                    points.Add(new Point(excelRange[i], excelRange[i+1]));
                    //test += $" {excelRange[i]} {excelRange[i+1]}\n";
                }
            }

            test.ItemsSource = points;
            return points;
        }

        private void ShowGraphic(List<Point> data)
        {
            var polyline = new Polyline();
            polyline.Stroke = Brushes.Orange; polyline.StrokeThickness = 3;

            foreach( var item in data)
            {
                polyline.Points.Add(item);
            }
            canvas.Children.Add(polyline);
            return;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ShowGraphic(GetData(dataPath.FullName, textBlock.Text));
        }
    }
}
