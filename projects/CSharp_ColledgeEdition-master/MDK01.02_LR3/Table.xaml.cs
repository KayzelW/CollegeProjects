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
using static MDK01._02_LR3.MainWindow;

namespace MDK01._02_LR3;

/// <summary>
/// Логика взаимодействия для Table.xaml
/// </summary>
public partial class Table : Window
{
    public Table()
    {
        InitializeComponent();
        Closing += Table_Closing;
    }

    private void Table_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        this.Hide();
        e.Cancel = true;
    }
}
