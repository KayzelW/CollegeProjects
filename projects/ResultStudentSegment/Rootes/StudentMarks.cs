using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultStudentSegment.Rootes
{
    internal class StudentMarks
    {
        public string name { get; set; }
        public string group { get; set; }
        public Dictionary<string, string> lessons = new Dictionary<string, string>();
        public HashSet<string> lessonsHS = new HashSet<string>();
        public List<string> marks = new List<string>();
        public string stateScholarship { get; set; }
        public int  stateInt { get; set; }
        /*
            0 - меньше предметов чем указано в группе
            1 - всё ок
            2 - есть тройка
            4 - стипендия базовая
            5 - повышенная
        */
        public StudentMarks() { }
        public StudentMarks(string input)
        {
            var str = input.Split(';');
            name = str[0];
            group = str[1];

            for (int i = 2; i < str.Length; i++)
            {
                var lesson = str[i].Split(':');
                lessons.Add(lesson[0], lesson[1]);
                lessonsHS.Add(lesson[0]);
                marks.Add(lesson[1]);
            }
        }
    }
}
