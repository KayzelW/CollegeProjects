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

//Виды документов (Код вида, название); 
public class DocType
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public DocType() { }
    public DocType(int id, string name)
    {
        Id = id;
        Name = name;
    }
    private DocType(List<string> documents) : this(int.Parse(documents[0]), documents[1])
    {

    }

    public static List<DocType> ReadFromFile(string localPath)
    {
        var file = new FileInfo(localPath + @"\ToRead\docTypes.txt");
        var text = File.ReadAllLinesAsync(file.FullName).Result;

        var result = new List<DocType>();
        foreach (var line in text)
        {
            result.Add(new DocType(line.Split().ToList()));
        }
        return result;
    }
}
