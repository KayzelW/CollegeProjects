using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;

namespace sorted_books;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public AppDbContext()
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Reader> Readers { get; set; }
    public DbSet<Library> Libraries { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Путь к базе данных SQLite. Файл будет создан в текущей директории приложения. (bin/Debug/)
        var databasePath = Path.Combine(Environment.CurrentDirectory, "MyDatabase.db");

        // Используем SQLite.
        optionsBuilder.UseSqlite($"Data Source={databasePath}");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Library>()
            .HasMany(library => library.Books)
            .WithOne(book => book.Library)
            .HasForeignKey(book => book.LibraryId);
        modelBuilder.Entity<Library>()
            .HasMany(library => library.Readers)
            .WithOne(reader => reader.Library)
            .HasForeignKey(reader => reader.LibraryId);
    }
}