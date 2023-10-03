using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FunnyWpf.Rootes
{
    internal class FunnyFunctions
    {
        public static string cubeButton(string input)
        {
            var num = Convert.ToInt32(input);
            return Convert.ToString(Math.Pow(num, 3));
        }
        public static string squareButton(string input)
        {
            var num = Convert.ToInt32(input);
            return Convert.ToString(Math.Pow(num, 2));
        }
        public static void BadResult(Window F)
        {
            F.Close();
        }
    }
}
