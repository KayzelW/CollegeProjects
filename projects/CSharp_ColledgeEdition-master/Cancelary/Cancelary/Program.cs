using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Reflection.Metadata;
using Cancelary.ContentClasses;
using Document = Cancelary.ContentClasses.Document;

namespace Cancelary;

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

        //var docs = Document.ReadFromFile(localPath);
        //var deps = Department.ReadFromFile(localPath);
        //var docTypes = DocType.ReadFromFile(localPath);

        //docTypes.ForEach(x => dbContext.DocTypes.Add(x));
        //docs.ForEach(x => dbContext.Documents.Add(x));
        //deps.ForEach(x => dbContext.Departments.Add(x));

        var docs = dbContext.Documents.ToList();
        var deps = dbContext.Departments.ToList();
        var docTypes = dbContext.DocTypes.ToList();

        dbContext.SaveChanges();

        var inputFile = new FileInfo($"{localPath}" + @"\ToRead\in.txt");
        var outputFile = new FileInfo($"{localPath}" + @"\ToRead\out.txt");
        Console.WriteLine("КодОтдела\tКодДокумента\tНазваниеДокумента\tДатаРегистрации");
        List<string> output = new List<string>
        {
            "КодОтдела\tКодДокумента\tНазваниеДокумента\tДатаРегистрации"
        };
        foreach (var line in File.ReadAllLinesAsync(inputFile.FullName).Result)
        {
            var str = line.Split();
            var result = docs.Where(x => (x.Sender == int.Parse(str[0])) );  //&& (x.DocTypeId == int.Parse(str[1])) - вырезано из-за малых входных данных
            foreach (var item in result)
            {
                output.Add(item.ToStringTab());
                Console.WriteLine(item.ToStringTab());
            }
        }
        File.WriteAllLinesAsync(outputFile.FullName, output);

    }
}

/*
10.	Канцелярия.
В базе данных хранятся сведения о движении документов на предприятии.
Таблицы: 
Виды документов (Код вида, название); 
Отделы (Код отдела, название); 
Документы (Код документа, название, номер, Код вида, Код отдела – отправителя, Код отдела – получателя, дата регистрации).
Требуется:
– найти служебные записки планового отдела;
– построить сравнительную диаграмму количества документов по каждому виду.
*/