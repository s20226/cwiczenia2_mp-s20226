using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZExporter
{
    internal class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return (x.FirstName == y.FirstName)
                && (x.LastName == y.LastName)
                && (x.IndexNumber == y.IndexNumber);
        }
        public int GetHashCode(Student obj)
        {
            return obj.IndexNumber.GetHashCode();
        }
    }
}
