using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;



namespace XYZExporter
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //1 opcja
            List<string> list = new List<string>();
            using (StreamReader stream = new StreamReader(@"C:\Users\mpazio\Downloads\OneDrive_2022-03-20\2. Ćwiczenia 2\Zadanie 1\dane.csv"))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            using (StreamWriter stream = new StreamWriter("opcja1.txt"))
            {
                foreach (var item in list)
                {
                    stream.WriteLine(item);
                }
            }
            //2 opcja
            string[] result2 = await File.ReadAllLinesAsync(@"C:\Users\mpazio\Downloads\OneDrive_2022-03-20\2. Ćwiczenia 2\Zadanie 1\dane.csv");
            await File.WriteAllLinesAsync("opcja2.txt", result2);

            string a = "";
            string[] b = a.Split(',');
            new Student { };
            //var jObject = new JObject();
            // { }
            var jArray = new JArray();
            // []
            var jProperty = new JProperty("property", 1);
            // nazwaProperty: ""
            //Root: {}, []
            var jObject = new JObject(
                new JProperty("uczelnia", new JObject(
                    new JProperty("createdAt", DateTime.Today.ToString("dd.MM.yyyy")),
                    new JProperty("author", "Michał Pazio")
                ))
            );
            Console.WriteLine(jObject);
        }
    }
}
