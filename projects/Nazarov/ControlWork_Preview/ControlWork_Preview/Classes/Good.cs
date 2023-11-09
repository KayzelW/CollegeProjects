using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork_Preview.Classes;

public class Good
{
    public Good(string line) : this()
    {
        var text = line.Split();
        Id = int.Parse(text[0]);
        Name = text[1];
        Category = text[2];
        Price = int.Parse(text[4]);
    }

    public Good() { } 

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Category { get; set; }
    public int Price { get; set; }
}
