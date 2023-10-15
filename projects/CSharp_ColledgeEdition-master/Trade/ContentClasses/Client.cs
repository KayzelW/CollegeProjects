using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Trade.ContentClasses
{
    public class Client 
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string City { get; private set; }
        public int Rating { get; private set; }
        [ForeignKey(nameof(Manager.Id))]
        public int ManagerID { get; private set; }
        public Client() { }
        public Client(string name, string city, int rating)
        {
            Name = name;
            City = city;
            Rating = rating;
        }
        private Client(List<string> data) : this(data[1], data[2], int.Parse(data[3]))
        {
            Id = int.Parse(data[0]);
            ManagerID = int.Parse(data[4]);
        }

        public override string ToString()
        {
            return new StringBuilder().Append(Id).Append(Name).Append(City).Append(Rating).Append(ManagerID).ToString();
        }
        public static ObservableCollection<Client> ReadFromFile(string localPath)
        {
            var file = new FileInfo(localPath + @"\ToRead\client.txt");
            var text = File.ReadAllLinesAsync(file.FullName).Result;

            var result = new ObservableCollection<Client>();
            foreach (var line in text)
            {
                result.Add(new Client(line.Split(';').ToList()));
            }
            return result;
        }
    }
}