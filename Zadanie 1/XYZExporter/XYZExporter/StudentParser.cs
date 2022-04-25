using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZExporter
{
    //1. Jako, że konstruktor nie może być asynchroniczny, poniżej jest przykład metody statycznej inicjalizującą klasę
    internal class StudentParser
    {
        private HashSet<Student> _students;
        public static async Task<StudentParser> Parse(List<string> studentDataList)
        {
            var students = new HashSet<Student>(new StudentComparer());
            foreach (var student in studentDataList)
            {
                await ParseStudentAsync(student, students);
            }
            return new StudentParser { _students = students };
        }
    }
    //2. Comparator, który możemy użyć w kolekcji np. HashSet
    var set = new HashSet<Student>(new StudentComparer());

}



