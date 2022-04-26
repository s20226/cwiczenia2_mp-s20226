using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XYZExporter.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ActiveStudies
    {

        public ActiveStudies(string name, int numbersOfStudents)
        {
            Name = name;
            NumberOfStudents = numbersOfStudents;
        }

        public string Name { get; set; }
        public int NumberOfStudents { get; set; }



    }
}