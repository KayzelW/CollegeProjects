using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Rootes.Studing
{
    internal class Student
    {
        public Student() { }
        public Student(int id)
        {
            this.studentId = id;
        }

        public Student(int Id, string Name) : this(Id)
        {
            this.studentName = Name;
        }

        private int studentId { get; set; }
        private string studentName { get; set; }

        public void PrintInfo ()
        {
            Console.WriteLine( Convert.ToString(studentId) + ' ' + studentName);
        }

        public static void newStudent(ref int Id, ref string Name, ref List<Student> listStudent)
        {
            listStudent.Add(new Student(Id, Name));
            Id = 0;
            Name = "";
        }
    }
}
