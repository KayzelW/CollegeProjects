using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace sorted_books;

public class Library : INotifyPropertyChanged
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();
    public ObservableCollection<Reader> Readers { get; set; } = new ObservableCollectionListSource<Reader>();
    public Library() { }

    public Library(string name)
    {
        Name = name;
    }
    public Library(string name, ref ObservableCollection<Book> books, ref ObservableCollection<Reader> readers) : this()
    {
        Name = name;
        Books = books;
        Readers = readers;
    }
    public bool TryAddBook(Book book)
    {
        try
        {
            Books.Add(book);
            Dirty();
        }
        catch { return false; }
        return true;
    }
    public bool TryRemoveBook(Book book)
    {
        try
        {
            if (Books.Remove(book)) Dirty();
        }
        catch { return false; }
        return true;
    } 
    public bool TryAddReader(Reader reader)
    {
        try
        {
            Readers.Add(reader);
            Dirty();
        }
        catch { return false; }
        return true;
    }
    public bool TryRemoveReader(Reader reader)
    {
        try
        {
            if(Readers.Remove(reader)) Dirty();
        }
        catch { return false; }
        return true;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void Dirty()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Book)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Reader)));
    }
}
