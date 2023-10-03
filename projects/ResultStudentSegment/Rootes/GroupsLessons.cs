using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultStudentSegment.Rootes
{
    internal class GroupsLessons
    {
        public string group { get; set;}
        public HashSet<string> lessons = new HashSet<string>();
        public GroupsLessons() { }
        public GroupsLessons(string input)
        {
            var str = input.Split(':');
            group = str[0];
            str = str[1].Split(',');
            foreach (var lesson in str)
            {
                lessons.Add(lesson);
            }
        }
    }
}
