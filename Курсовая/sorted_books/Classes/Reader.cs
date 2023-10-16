using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sorted_books.Classes;

public class Reader : INotifyPropertyChanged
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }
    [ForeignKey(nameof(Library))]
    public int LibraryId { get; set; }
    public Library Library { get; set; }
    public string Name { get; private set; }
    public string SecondName { get; private set; }
    public string Group { get; private set; }
    public List<Book> BooksArended { get; private set; }
    public Reader(string name, string secondName, string group)
    {
        Name = name;
        SecondName = secondName;
        Group = group;
    }
    public bool TryAddArrendBook(Book book)
    {
        try
        {
            BooksArended.Add(book);
            Dirty();
        }
        catch { return false; }
        return true;
    }
    public bool TryRemoveArrendBook(Book book)
    {
        try
        {
            BooksArended.Remove(book);
            Dirty();
        }
        catch { return false; }
        return true;
    }
    public static bool TryReaderReadFromFile(string pathInput, ObservableCollection<Reader> readers)
    {
        try
        {
            FileInfo inputFile = new FileInfo(pathInput);
            var lines = File.ReadAllLines(inputFile.FullName).ToList();

            foreach (var line in lines)
            {
                var s = line.Split();
                var reader = new Reader(s[0], s[1], s[2]);
                readers.Add(reader);
            }
        }
        catch { return false; }

        return true;
    }
    public override string ToString()
    {
        return $"{Name} {SecondName} {Group}";
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void Dirty()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BooksArended)));
    }
}

public class ReaderComparer : IComparer<Reader>
{
    int IComparer<Reader>.Compare(Reader? x, Reader? y)
    {
        return x.Name.CompareTo(y.Name);
    }
}