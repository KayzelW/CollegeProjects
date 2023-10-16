using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;

namespace Cancelary.ContentClasses;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public AppDbContext()
    {
    }

    public DbSet<DocType> DocTypes { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Путь к базе данных SQLite. Файл будет создан в текущей директории приложения. (bin/Debug/)
        var databasePath = Path.Combine(Environment.CurrentDirectory, "MyDatabase.db");

        // Используем SQLite.
        optionsBuilder.UseSqlite($"Data Source={databasePath}");
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    
    //}
}