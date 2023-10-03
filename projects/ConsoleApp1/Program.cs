namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var func = (int x, int y) =>
            {
                return x + y;
            };
            var str = Console.ReadLine().Split(' ');
            Console.WriteLine(func(int.Parse(str[0]), int.Parse(str[1])));
        }
    }
}