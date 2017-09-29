using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Dataformatter.Dataprocessing.Processors;
using Newtonsoft.Json.Linq;

namespace Dataformatter.Dataprocessing.CsvParsing
{
    public static class JsonReader<T>
    {
        public static Dictionary<string, T[]> ParseJsonToListOfObjects(EntityNames name)
        {
            Console.WriteLine("I got called");
            var fileInDirectory = Directory.GetFiles("ProcessedData/");
            var nameOfEnum = Enum.GetName(typeof(EntityNames), name);
            var allFiles = new Dictionary<string, string>();
            foreach (var file in fileInDirectory)
            {
                if (file.Contains(nameOfEnum))
                    allFiles.Add(file.Substring(file.IndexOf('_') + 1, 3), file.Substring(file.IndexOf('/') + 1));
            }

            return allFiles.ToDictionary(s => s.Key, s => ParseJsonToListOfObjects(s.Value));
        }

        public static T[] ParseJsonToListOfObjects(string name)
        {
            var fileLocation = "ProcessedData/" + name;
            var rootObject = JArray.Parse(File.ReadAllText(fileLocation));
            var objectList = rootObject.ToObject<T[]>();
            return objectList;
        }
    }
}