using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PathsPractice;

public class DataPath : INotifyPropertyChanged
{
    private Geometry path;

    public Geometry Path
    {
        get {  return Path; }
        set
        {
            Path = value;
            OnPropertyChanged(nameof(Path));
        }
    }

    // Допустим, у вас есть метод для создания пути в коде.
    public void UpdatePathData()
    {
        PathGeometry pathGeometry = new PathGeometry();
        PathFigure pathFigure = new PathFigure();
        // Добавьте сюда ваш код для создания пути.

        pathGeometry.Figures.Add(pathFigure);
        Path = pathGeometry;
    }

    // Реализация интерфейса INotifyPropertyChanged для обновления привязанных данных.
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
