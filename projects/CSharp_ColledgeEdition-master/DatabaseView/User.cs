using System.ComponentModel;
using System.Runtime.CompilerServices;

public class User : INotifyPropertyChanged
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public User() { }
    public User(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public override string ToString()
    {
        return $"{Id} {Name} {Email}";
    }

    public void Dirty()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
    }
}