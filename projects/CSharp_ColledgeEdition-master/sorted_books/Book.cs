using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace sorted_books;

public class Book //: INotifyPropertyChanged
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int LibraryId { get; set; }
    public Library Library { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Page { get; set; }
    public int AgeRelease { get; set; }
    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public Book(string title, string author, int page, int ageRelease) : this(title, author)
    {
        Page = page;
        AgeRelease = ageRelease;
    }

    public override string ToString()
    {
        if (Page == null || AgeRelease == null)
        {
            return $"{Title} {Author};";
        }
        return $"{Title} {Author} {Page} {AgeRelease};";
    }

    public static bool TryBookReadFromFile(string pathInput, ref AppDbContext dbContext)
    {
        try
        {
            FileInfo inputFile = new FileInfo(pathInput);
            var lines = File.ReadAllLines(inputFile.FullName).ToList();

            foreach (var line in lines)
            {
                var s = line.Split();
                dbContext.Books.Add(new Book(s[0], s[1], int.Parse(s[2]), int.Parse(s[3])));
            }
        }
        catch { return false; }

        return true;
    }

    //
    //              Не нужный код
    //
    //public event PropertyChangedEventHandler? PropertyChanged;
    //
    //public void Dirty()
    //{
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Author)));
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Page)));
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AgeRelease)));
    //}
}

public class BookComparer : IComparer<Book>
{
    int IComparer<Book>.Compare(Book? x, Book? y)
    {
        return x.Title.CompareTo(y.Title);
    }
}