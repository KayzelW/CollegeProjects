using System.Text;

namespace useful;

public class Program
{
    static void Main(string[] args)
    {
        var str = new string[] { "push Привет! Это снова я! Пока!", "pop 5", "push Как твои успехи? Плохо?", "push qwertyuiop", "push 1234567890", "pop 26" };
        Console.WriteLine(ApplyCommands(str));
    }

    private static string ApplyCommands(string[] commands)
    {
        StringBuilder result = new StringBuilder();
        foreach (string command in commands)
        {
            var temp = command.Split(' ', 2).ToList();
            switch (temp[0])
            {
                case "push":
                    result.Append(temp[1]);
                    break;
                case "pop":
                    result.Length = result.Length - int.Parse(temp[1]);
                    break;
            }
        }
        return result.ToString();
    }
}