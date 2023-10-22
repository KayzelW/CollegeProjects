using Microsoft.EntityFrameworkCore;
using sorted_books.Classes;

namespace sorted_books;

public class Program
{
    public static AppDbContext? dbContext { get; set; }
    private static string executePath { get; set; } = Environment.CurrentDirectory;
    private static string localPath { get; set; } = executePath.Substring(0, executePath.IndexOf(@"\bin"));
    static void Main(string[] args)
    {
        var databasePath = Path.Combine(executePath, "MyDatabase.db"); //Путь к БД
        var connectionString = $"Data Source={databasePath}"; // Строка подключения
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>(); // Конфигуратор БД
        optionsBuilder.UseSqlite(connectionString); // Использовать эту строку подключения
        dbContext = new AppDbContext(optionsBuilder.Options); // создание объекта БД
        dbContext.Database.EnsureCreated();

        Console.WriteLine("ReadyForWork");
        dbContext.Books.ToList().ForEach(x => Console.WriteLine(x.ToString()));

        //MainWindow mainWindow = new MainWindow();
    }
    private void ExecuteSmth(AppDbContext dbContext)
    {
        var pathInputBooks = localPath + @"\ToRead\books.txt";
        var pathInputReaders = localPath + @"\ToRead\readers.txt";


        var library = new Library("Library2");
        var books = library.Books;
        var readers = library.Readers;

        try
        {
            Book.TryBookReadFromFile(pathInputBooks, books);
            Reader.TryReaderReadFromFile(pathInputReaders, readers);
            library.Dirty();
        }
        catch { Environment.Exit(69); }

        //File.WriteAllLinesAsync(outputFile.FullName, books.Select(book => book.ToString()));

        dbContext.Libraries.Add(library);
        dbContext.SaveChanges();
    }
}