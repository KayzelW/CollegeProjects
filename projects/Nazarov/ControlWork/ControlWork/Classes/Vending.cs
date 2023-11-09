using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml.Linq;
using System.ComponentModel;

namespace ControlWork.Classes;

public class Vending : INotifyPropertyChanged
{
    public Vending(int Id, string model, string year, string color, string country) : this() =>
        (this.Id, this.Model, this.Year, this.Color, this.CountryPerformer) = (Id, model, year, color, country);

    public Vending() { }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Model { get; set; }
    public string? Year { get; set; }
    public string? Color { get; set; }
    public string? CountryPerformer { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void Dirty()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Model)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Year)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CountryPerformer)));
    }
}
