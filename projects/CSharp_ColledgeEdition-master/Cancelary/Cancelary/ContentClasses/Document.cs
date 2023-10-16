using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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

//Документы (Код документа, название, номер, Код вида, Код отдела – отправителя, Код отдела – получателя, дата регистрации).
public class Document
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Number { get; set; }
    [ForeignKey(nameof(DocType.Id))]
    public int DocTypeId { get; set; }
    [ForeignKey(nameof(Department.Id))]
    public int Sender { get; set; }
    [ForeignKey(nameof(Department.Id))]
    public int Recipient { get; set; }
    public DateTime RegistrationTime { get; set; }

    public Document() { }
    public Document(int id, string name, int number, int docTypeId, int sender, int recipient, DateTime registrationTime)
    {
        Id = id;
        Name = name;
        Number = number;
        DocTypeId = docTypeId;
        Sender = sender;
        Recipient = recipient;
        RegistrationTime = registrationTime;
    }
    private Document(List<string> documents) : this(int.Parse(documents[0]), documents[1], int.Parse(documents[2]), int.Parse(documents[3]),
        int.Parse(documents[4]), int.Parse(documents[5]), DateTime.Parse(documents[6], CultureInfo.InvariantCulture))
    {

    }
    public override string ToString()
    {
        return $"{Id} {Name} {Number} {DocTypeId} {Sender} {Recipient} {RegistrationTime}";
    }
    public string ToStringTab()
    {
        return $"{Sender} {Number} {Name} {RegistrationTime.ToShortDateString()}";
    }
    public static List<Document> ReadFromFile(string localPath)
    {
        var file = new FileInfo(localPath + @"\ToRead\docs.txt");
        var text = File.ReadAllLinesAsync(file.FullName).Result;

        var result = new List<Document>();
        foreach (var line in text)
        {
            result.Add(new Document(line.Split().ToList()));
        }       
        return result;
    }
}
