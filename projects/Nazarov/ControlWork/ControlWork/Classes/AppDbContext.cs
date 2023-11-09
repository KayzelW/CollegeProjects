using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace ControlWork.Classes;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    protected AppDbContext() { }
    public DbSet<Good> Goods { get; set; }
    public DbSet<Vending> Vendings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Путь к базе данных SQLite. Файл будет создан в текущей директории приложения. (bin/Debug/)
        var databasePath = Path.Combine(Environment.CurrentDirectory, "MyDatabase.db");

        // Используем SQLite.
        optionsBuilder.UseSqlite($"Data Source={databasePath}");
    }
}
