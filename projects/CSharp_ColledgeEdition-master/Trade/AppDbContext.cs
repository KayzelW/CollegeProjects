using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using Trade;
using Trade.ContentClasses;

namespace sorted_books;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public AppDbContext()
    {
    }

    public DbSet<Manager> Managers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<TradeOffer> Trades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Путь к базе данных SQLite. Файл будет создан в текущей директории приложения. (bin/Debug/)
        var databasePath = Path.Combine(Environment.CurrentDirectory, "MyDatabase.db");

        // Используем SQLite.
        optionsBuilder.UseSqlite($"Data Source={databasePath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TradeOffer>().HasMany(o => o.Orders);
        modelBuilder.Entity<TradeOffer>().HasMany(o => o.Managers);
        modelBuilder.Entity<TradeOffer>().HasMany(o => o.Clients);
    }
}