using Microsoft.EntityFrameworkCore;

namespace sorted_books;

internal class Program
{
    static void Main(string[] args)
    {
        string executePath = Environment.CurrentDirectory;
        var databasePath = Path.Combine(executePath, "MyDatabase.db"); //Путь к БД
        var connectionString = $"Data Source={databasePath}"; // Строка подключения
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>(); // Конфигуратор БД
        optionsBuilder.UseSqlite(connectionString); // Использовать эту строку подключения
        AppDbContext dbContext = new AppDbContext(optionsBuilder.Options); // создание объекта БД
        dbContext.Database.EnsureCreated();

        

        Console.WriteLine("ReadyForWork");

        //MainWindow mainWindow = new MainWindow();
    }
    private void ExecuteSmth(string executePath, AppDbContext dbContext)
    {
        var localPath = executePath.Substring(0, executePath.IndexOf("\\bin"));
        var pathInputBooks = localPath + "\\books.txt";
        var pathOutput = localPath + "\\output.txt";
        var pathInputReaders = localPath + "\\readers.txt";

        FileInfo outputFile = new FileInfo(pathOutput);

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