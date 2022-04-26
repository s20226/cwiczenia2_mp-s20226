using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using XYZExporter.Comparers;
using XYZExporter.Models;
using XYZExporter.Validators;

namespace XYZExporter
{
    public class Program
    {
        private static readonly DataValidator _dataValidator = new DataValidator();
        public static void Logg(string msg)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.WriteLine($"Error: {msg}");
            }
        }

        static void Main(string[] args)
        {
            if (ArgumentsValidator(args))
            {
                string msg = "Wrongs arguments, should be: 3 path to CSV, outputPath, FormatOutputFile";
                Logg(msg);
                throw new ArgumentException(msg);
            }

            var fileCSV = args[0];
            var outPutPath = args[1];
            var format = args[2];


            var studensHashSet = new HashSet<Student>(new StudentComparer());
            Dictionary<string, int> dict = new Dictionary<string, int>();
            var activeStudiesList = new List<ActiveStudies>();

            StreamReader reader = null;
            try
            {
                reader = new StreamReader(fileCSV);
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    List<string> splited = new List<string>(line.Split(','));

                    if (!_dataValidator.HasValidDataStudentsRow(splited))
                    {

                        Logg(line);
                        continue;
                    }


                    var s = new Student
                    {
                        FirstName = splited[0],
                        LastName = splited[1],
                        Studies = new Studies(splited[2], splited[3]),
                        IndexNumber = splited[4],
                        BirthDate = DateTime.Parse(splited[5]).ToString("dd.MM.yyyy"),
                        Email = splited[6],
                        MothersName = splited[7],
                        FathersName = splited[8]
                    };

                    studensHashSet.Add(s);

                }
                SetActiveStudies(studensHashSet, dict, activeStudiesList);

            }
            catch (FileNotFoundException e)
            {
                var msg = $"File {fileCSV} not found.";
                Logg(msg);
                throw new FileNotFoundException(msg, e);
            }
            catch (IOException e)
            {
                var msg = $"File {fileCSV} can't be load.";
                Logg(msg);
                throw new FileLoadException(msg, e);
            }
            finally
            {
                if (reader != null)
                { reader.Dispose(); }
            }


            University university = new University("Jan Kowalski", studensHashSet, DateTime.Now, activeStudiesList);


            switch (format)
            {
                case "json":
                    using (var streamWriter = new StreamWriter(outPutPath))
                    {

                        streamWriter.Write(JsonConvert.SerializeObject(new { uczelnia = university }, Formatting.Indented));
                    }
                    break;

                case "xml":
                    using (var streanWriter = new StreamWriter(outPutPath))
                    {
                        var xmlSerializer = new XmlSerializer(university.GetType());
                        xmlSerializer.Serialize(streanWriter, university);
                    }
                    break;
            }

        }

        private static bool ArgumentsValidator(string[] args)
        {
            return args.Length != 3 || args[0] == null || args[1] == null || args[2] == null;
        }

        private static void SetActiveStudies(HashSet<Student> studensHashSet, Dictionary<string, int> dict, List<ActiveStudies> activeStudiesList)
        {
            foreach (Student s in studensHashSet)
            {

                if (!dict.ContainsKey(s.Studies.Name))
                {
                    dict.Add(s.Studies.Name, 1);
                }
                else
                {
                    dict[s.Studies.Name]++;
                }

            }

            foreach (var (key, value) in dict)
            {
                activeStudiesList.Add(new ActiveStudies(key, value));

            }



        }
    }
}
