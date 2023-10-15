using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Trade.ContentClasses
{
    public class Manager
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Comm { get; set; } = string.Empty;
        public Manager() { }
        public Manager(string name, string city, string comm)
        {
            Name = name;
            City = city;
            Comm = comm;
        }
        private Manager(List<string> data) : this(data[1], data[2], data[3])
        {
            Id = int.Parse(data[0]);
        }
        public override string ToString()
        {
            return new StringBuilder().Append(Name).Append(City).Append(Comm).ToString();
        }
        public static ObservableCollection<Manager> ReadFromFile(string localPath)
        {
            var file = new FileInfo(localPath + @"\ToRead\manager.txt");
            var text = File.ReadAllLinesAsync(file.FullName).Result;

            var result = new ObservableCollection<Manager>();
            foreach (var line in text)
            {
                result.Add(new Manager(line.Split(';').ToList()));
            }
            return result;
        }
    }
}