using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace XYZExporter.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class University
    {
        public string Author { get; set; }
        public string CreatedAt { get; set; }
        [JsonProperty("studenci")]
        public HashSet<Student> Students { get; set; }
        public List<ActiveStudies> ActiveStudies { get; set; }



        public University(string author, HashSet<Student> students, DateTime createdAt, List<ActiveStudies> activeStudiesList)
        {
            CreatedAt = createdAt.ToString("dd.MM.yyyy");
            Author = author;
            Students = students;
            ActiveStudies = activeStudiesList;
        }



    }
}
