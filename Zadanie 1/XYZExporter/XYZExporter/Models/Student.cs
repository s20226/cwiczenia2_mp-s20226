using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XYZExporter.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Student
    {
        public string IndexNumber { get; set; }
        [JsonProperty("fname")]
        public string FirstName { get; set; }
        [JsonProperty("lname")]
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public Studies Studies { get; set; }


    }
}