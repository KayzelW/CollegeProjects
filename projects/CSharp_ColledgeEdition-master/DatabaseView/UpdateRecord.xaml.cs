using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DatabaseView
{
    /// <summary>
    /// Логика взаимодействия для UpdateRecord.xaml
    /// </summary>
    public partial class UpdateRecord : Window
    {
        public UpdateRecord()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрытие окна редактирования
            Close();
        }
    }
}
