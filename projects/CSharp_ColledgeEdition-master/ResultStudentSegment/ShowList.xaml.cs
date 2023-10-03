using ResultStudentSegment.Rootes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ResultStudentSegment
{
    /// <summary>
    /// Логика взаимодействия для ShowList.xaml
    /// </summary>
    public partial class ShowList : UserControl
    {
        public ShowList()
        {
            InitializeComponent();
            userControlWindow.Visibility = Visibility.Visible;
        }
        public void getData<T1, T2>(HashSet<T1> hashSet1, HashSet<T2> hashSet)
        {

        }
    }
}
