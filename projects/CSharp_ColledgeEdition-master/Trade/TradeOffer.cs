using sorted_books;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Trade.ContentClasses;

namespace Trade
{
    public class TradeOffer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TradeId { get; private set; }
        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
        public ObservableCollection<Manager> Managers { get; set; } = new ObservableCollection<Manager>();
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();

        public TradeOffer() { }
        public TradeOffer(string localPath)
        {
            TryReadFromFile(localPath);
        }

        #region AddAndRemove
        public void addManager(Manager manager)
        {
            Managers.Add(manager);
        }
        public void removeManager(Manager manager)
        {
            Managers.Remove(manager);
        }
        public void addOrder(Order order)
        {
            Orders.Add(order);
        }
        public void removeOrder(Order order)
        {
            Orders.Remove(order);
        }
        public void addClient(Client client)
        {
            Clients.Add(client);
        }
        public void removeClient(Client client)
        {
            Clients.Remove(client);
        }
        #endregion

        /// <summary>
        /// Функция читает файлы во внутренние поля.
        /// </summary>
        /// <param name="localPath"></param>
        public void ReadFromFile(string localPath)
        {
            this.Clients = Client.ReadFromFile(localPath);
            this.Managers = Manager.ReadFromFile(localPath);
            this.Orders = Order.ReadFromFile(localPath);
        }

        /// <summary>
        /// Пробует читать файлы во внутренни поля
        /// </summary>
        /// <param name="localPath"></param>
        /// <returns></returns>
        public bool TryReadFromFile(string localPath)
        {
            try
            {
                ReadFromFile(localPath);
                return true;
            }
            catch { return false; }
        }
    }
}
