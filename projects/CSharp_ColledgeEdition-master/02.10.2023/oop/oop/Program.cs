using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> staff = new List<Person>();
            staff.Add(new Person("A", "a", 2));
            staff.Add(new Person("B", "b"));
            staff.Add(new Person("C", "c", 0));

            var minQual = staff.Min(x => x.qual);
            var elem = (Person)staff.Find(x => x.qual == minQual);
            staff.Remove(elem);
            elem = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^\n\n\n\n");
        }
    }

    public class Person
    {
        public string name { get; private set; }
        public string secondName { get; private set; }
        public int qual { get; private set; }
        public Person(string name, string secondName, int qual = 0)
        {
            this.name = name;
            this.secondName = secondName;
            this.qual = qual;
        }
        public override string ToString()
        {
            return $"{name} {secondName} {qual}";
        }
        ~Person()
        {
            Console.WriteLine($"До свидания, мистер {name} {secondName}");
        }
    }
}
