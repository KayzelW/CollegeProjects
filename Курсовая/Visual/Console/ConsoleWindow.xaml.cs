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

namespace Visual.Console;

/// <summary>
/// Логика взаимодействия для ConsoleWindow.xaml
/// </summary>
public partial class ConsoleWindow : Window
{
    public ConsoleWindow()
    {
        InitializeComponent();
        System.Console.SetOut(new TextBoxWriter(ConsoleTextBox));
    }
    public class TextBoxWriter : System.IO.TextWriter
    {
        private TextBox textBox;

        public TextBoxWriter(TextBox textBox)
        {
            this.textBox = textBox;
        }

        public override void WriteLine(char value)
        {
            if (value == '\n')
            {
                textBox.Dispatcher.Invoke(() => textBox.AppendText(Environment.NewLine));
            }
            else
            {
                textBox.Dispatcher.Invoke(() => textBox.AppendText(value.ToString()));
            }
        }

        public override void Write(string value)
        {
            textBox.Dispatcher.Invoke(() => textBox.AppendText(value));
        }

        public override System.Text.Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }

}
