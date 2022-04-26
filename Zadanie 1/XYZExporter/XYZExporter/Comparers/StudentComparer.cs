using System.Collections.Generic;
using XYZExporter.Models;

namespace XYZExporter.Comparers
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
