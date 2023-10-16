using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cancelary.ContentClasses;

//Отделы (Код отдела, название); 
public class Department
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public Department() { }
    public Department(int id, string name)
    {
        Id = id;
        Name = name;
    }

    private Department(List<string> documents) : this(int.Parse(documents[0]), documents[1])
    {

    }

    public static List<Department> ReadFromFile(string localPath)
    {
        var file = new FileInfo(localPath + @"\ToRead\departmens.txt");
        var text = File.ReadAllLinesAsync(file.FullName).Result;

        var result = new List<Department>();
        foreach (var line in text)
        {
            result.Add(new Department(line.Split().ToList()));
        }
        return result;
    }
}
