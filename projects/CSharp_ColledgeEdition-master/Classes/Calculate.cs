using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Classes;

public class Calculate
{
    public Calculate() { }
    public List<GraphicResult> data = new List<GraphicResult>();

    public List<GraphicResult> Execute(string x1TextBox, string x2TextBox, string aTextBox, string bTextBox, string dxTextBox)
    {
        var x1 = int.Parse(x1TextBox);
        var x2 = int.Parse(x2TextBox);
        var a = int.Parse(aTextBox);
        var b = int.Parse(bTextBox);
        var dx = int.Parse(dxTextBox);

        data.Clear();
        ExecuteCalc(ref data, x1, x2, dx, a, b);

        return data;
    }

    public static void ExecuteCalc(ref List<GraphicResult> data, int x1, int x2, int dx, int a, int b)
    {
        for (int i = x1; i <= x2; i += dx)
        {
            if (i != 0)
            {
                data.Add(new GraphicResult(
                    Math.Abs(Math.Pow(2 * a - 7.5 * i, 3)) + Math.Pow(Math.E, ((2 * b) / i) - a / (2 * b))
                , i));
            }
            else
            {
                data.Add(new GraphicResult(0, i));
            }
        }
    }

    public struct GraphicResult
    {
        public double value { get; private set; }
        public int x { get; private set; }
        public GraphicResult(double input, int i) => (this.value, this.x) = (Math.Round(input, 2), i);
    }
}
