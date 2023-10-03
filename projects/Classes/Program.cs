using Classes.Rootes.Studing;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(@"E:\kapit\inputMixed.txt");
            file.OpenRead();
            var listString = File.ReadAllText(file.FullName).Split('\r', '\n', ' ');
            List<Student> listStudent = new List<Student>();
            Student student = new Student();
            int id = 0; 
            string name = "";

            foreach ( var item in listString )
            {
                if (item == "")
                {
                    continue;
                }
                try
                {
                    id = Convert.ToInt32(item!);
                }
                catch
                {
                    name = item!;
                }
                if ( id != 0 && name != "" ) 
                {
                    Student.newStudent(ref id, ref name, ref listStudent);
                }                  
            }

            foreach (var x in listStudent)
            {
                x.PrintInfo();
            }
        }
    }
}