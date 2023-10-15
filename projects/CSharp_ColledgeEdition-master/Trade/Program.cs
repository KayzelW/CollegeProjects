using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using sorted_books;
using Trade.ContentClasses;

namespace Trade
{
    public class Program
    {
        static void Main(string[] args)
        {
            string executePath = Environment.CurrentDirectory;
            var localPath = executePath.Substring(0, executePath.IndexOf(@"\bin"));

            var databasePath = Path.Combine(localPath, "MyDatabase.db"); //Путь к БД
            var connectionString = $"Data Source={databasePath}"; // Строка подключения
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>(); // Конфигуратор БД
            optionsBuilder.UseSqlite(connectionString); // Использовать эту строку подключения
            AppDbContext dbContext = new AppDbContext(optionsBuilder.Options); // создание объекта БД
            dbContext.Database.EnsureCreated();

            var trades = dbContext.Trades.ToList();

            //Закоментированный тест ввода из файла.

            //trade.ReadFromFile(localPath);
            //dbContext.Trades.Add(trade);
            //dbContext.SaveChanges();
            //Environment.Exit(1); //БД пуста - заполнение из файлов
            //Console.WriteLine("Done");
            
            var orders = dbContext.Orders.ToList();
            var comparer = new OrderComparer();
            orders.Sort(comparer);
            orders.Reverse();
            Console.WriteLine(@"Id ManagerId ClientId OrderDate Amount");
            orders.ForEach(x => Console.WriteLine(x));

            dbContext.SaveChanges();
        }
    }
}