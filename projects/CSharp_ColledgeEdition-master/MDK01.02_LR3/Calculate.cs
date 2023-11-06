using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MDK01._02_LR3;

public class Calculate
{
    public MainWindow mainWindow;
    public Calculate() { }

    public bool Execute()
    {
        if (mainWindow.data.Count != 0
    && MessageBox.Show("Обнулить вычисления?", "Вопрос", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            mainWindow.data = new List<MainWindow.GraphicResult>();
            mainWindow.tableWindow.dataGrid.ItemsSource = null;
            mainWindow.tableWindow.dataGrid.Items.Refresh();
            mainWindow.tableWindow.dataGrid.ItemsSource = mainWindow.data;
        }

        if (int.TryParse(mainWindow.x1TextBox.Text, out var x1)) { }
        else { Erase("x1 не целое число"); return false; }
        if (int.TryParse(mainWindow.x2TextBox.Text, out var x2)) { }
        else { Erase("x2 не целое число"); return false; }
        if (int.TryParse(mainWindow.x2TextBox.Text, out var a)) { }
        else { Erase("a не целое число"); return false; }
        if (int.TryParse(mainWindow.x2TextBox.Text, out var b)) { }
        else { Erase("b не целое число"); return false; }
        if (int.TryParse(mainWindow.dxTextBox.Text, out var dx)) { }
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

        if (dx <= 0)
        {
            Erase("dx должно быть > 0");
            return false;
        }

        if (dx >= x2 - x1)
        {
            Erase("dx больше отрезка");
            return false;
        }

        mainWindow.data.Clear();
        for (int i = x1; i <= x2; i += dx)
        {
            if (i != 0)
            {
                mainWindow.data.Add(new MainWindow.GraphicResult(
                    Math.Abs(Math.Pow(2 * a - 7.5 * i, 3)) + Math.Pow(Math.E, ((2 * b) / i) - a / (2 * b))
                , i));
            }
            else
            {
                mainWindow.data.Add(new MainWindow.GraphicResult(0, i));
            }
        }
        return true;
    }

    

    private void Erase()
    {
        mainWindow.x1TextBox.Text = string.Empty;
        mainWindow.x2TextBox.Text = string.Empty;
        mainWindow.aTextBox.Text = string.Empty;
        mainWindow.bTextBox.Text = string.Empty;
        mainWindow.dxTextBox.Text = string.Empty;
    }

    private void Erase(string Error)
    {
        Erase();
        mainWindow.errorView.Visibility = Visibility.Visible;
        mainWindow.errorTextBlock.Text = Error;
    }
}
