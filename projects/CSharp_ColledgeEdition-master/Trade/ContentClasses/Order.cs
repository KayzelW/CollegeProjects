using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Trade.ContentClasses
{
    public class Order
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        [ForeignKey(nameof(Manager.Id))]
        public int ManagerId { get; private set; }
        [ForeignKey(nameof(Client.Id))]
        public int ClientId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public double Amount { get; protected set; }

        public Order() { }
        public Order(DateTime orderDate, double amount)
        {
            this.OrderDate = orderDate;
            this.Amount = amount;
        }
        /// <summary>
        /// Внутренний конструктор.
        /// </summary>
        /// <param name="data"></param>
        private Order(List<string> data) : this(DateTime.Parse(data[3], CultureInfo.InvariantCulture), double.Parse(data[4].Replace('.', ',')))
        {
            Id = int.Parse(data[0]);
            ManagerId = int.Parse(data[1]);
            ClientId = int.Parse(data[2]);
        }

        public override string ToString()
        {
            return new StringBuilder().Append(Id).Append(ManagerId).Append(ClientId).Append(OrderDate).ToString();
        }

        /// <summary>
        /// Функция читает файлы и возвращает список.
        /// </summary>
        /// <param name="localPath"></param>
        /// <returns></returns>
        public static ObservableCollection<Order> ReadFromFile(string localPath)
        {
            var file = new FileInfo(localPath + @"\ToRead\order.txt");
            var text = File.ReadAllLinesAsync(file.FullName).Result;

            var result = new ObservableCollection<Order>();
            foreach (var line in text)
            {
                result.Add(new Order(line.Split(';').ToList()));
            }
            return result;
        }
    }
}