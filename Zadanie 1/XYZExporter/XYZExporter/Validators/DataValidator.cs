using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZExporter.Validators
{
   public class DataValidator
    {
        private const int NumbersOfColumn = 9;

        public bool HasValidDataStudentsRow(List<String> studentData)
        {
            
            return studentData.Count == 9 && !(studentData.Contains("") || studentData.Contains(null));
        }
    }
}
