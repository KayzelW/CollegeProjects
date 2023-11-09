using ControlWork.Classes;
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

namespace ControlWork.Windows;
public partial class AddMachine : Window
{
    public Classes.Vending LocalVending { get; private set; }

    public AddMachine()
    {
        InitializeComponent();
    }

    public void EditVending(Vending vending)
    {
        LocalVending = vending;

        Id.Text = vending.Id.ToString();
        Id.IsEnabled = false;
        Model.Text = vending.Model;
        Year.Text = vending.Year;
        Color.Text = vending.Color;
        CountryPerformer.Text = vending.CountryPerformer;
        this.ShowDialog();
        GetVendings();
        Id.IsEnabled = true;
    }

    public void AddVending()
    {
        Id.Text = Model.Text = Year.Text = Color.Text = CountryPerformer.Text = "";
        this.ShowDialog();
        GetVendings();
    }

    private void GetVendings()
    {
        try
        {
            LocalVending = new Classes.Vending(int.Parse(Id.Text), Model.Text, Year.Text, Color.Text, CountryPerformer.Text);
        }
        catch
        {
            LocalVending = null;
        }
    }
        

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}