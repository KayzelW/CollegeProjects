using ResultStudentSegment.Rootes;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ResultStudentSegment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Environment.CurrentDirectory;
            path = path.Substring(0, path.IndexOf(@"bin\Debug"));
            
            FileInfo groupsFile = new FileInfo(path + "GroupsLessons.txt");
            FileInfo studentsFile = new FileInfo(path + "StudentsMarks.txt");

            HashSet<GroupsLessons> groups = new HashSet<GroupsLessons>();
            HashSet<StudentMarks> students = new HashSet<StudentMarks>();

            var groupsString = File.ReadAllLines(groupsFile.FullName);
            var studentsString = File.ReadAllLines(studentsFile.FullName);

            foreach (var groupLine in groupsString)
            {
                groups.Add(new GroupsLessons(groupLine));
            }

            foreach (var studentLine in studentsString)
            {
                students.Add(new StudentMarks(studentLine));
            }

            //bool canEscape = false;

            foreach (var student in students)
            {
                foreach (var group in groups)
                {
                    if (student.group == group.group)
                    {
                        if (student.lessonsHS.Count == group.lessons.Count)
                        {
                            if (student.marks.Contains(Convert.ToString(3)))
                            {
                                student.stateScholarship = "Есть тройка";
                                student.stateInt = 2;
                            }

                            var countLesson = student.lessons.Count;
                            foreach(var lessonGR in group.lessons)
                            {
                                if (student.lessons.Keys.Contains(lessonGR))
                                {
                                    countLesson--;
                                }
                            }
                            if (countLesson == 0)
                            {
                                int mark = 0;
                                foreach ( var markNow in student.marks)
                                {
                                    mark += int.Parse(markNow);
                                }
                                if (mark/student.marks.Count == 5)
                                {
                                    student.stateScholarship = "Повышенная";
                                    student.stateInt = 5;
                                }
                                else
                                {
                                    student.stateScholarship = "Есть четвёрки";
                                    student.stateInt = 4;
                                }
                            }
                        }
                        else
                        {
                            student.stateScholarship = "Не сданы все предметы";
                            student.stateInt = 0;
                        }
                    }
                }
            }

            /*
            foreach (var student in students)
            {
                Console.WriteLine($"{student.name} - {student.stateScholarship}");
            }
            */

            ShowList window = new ShowList();
            window.getData<StudentMarks, GroupsLessons>(students, groups);
        }
    }
}
