using System.Collections.Generic;
using XYZExporter.Models;

namespace XYZExporter.Comparers
{
    internal class ActiveStudiesComparer : IEqualityComparer<ActiveStudies>
    {
        public bool Equals(ActiveStudies x, ActiveStudies y)
        {
            return (x.Name == y.Name)
               ;
        }
        public int GetHashCode(ActiveStudies obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}