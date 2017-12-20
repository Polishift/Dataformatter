using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dataformatter.Dataprocessing.Processors;
using Newtonsoft.Json.Linq;

namespace Dataformatter.Dataprocessing.Parsing
{
    public static class JsonReader<T>
    {
        public static Dictionary<string, T[]> ParseJsonToListOfObjects(EntityNames name)
        {
            var fileInDirectory = Directory.GetFiles(Paths.ProcessedDataFolder);
            var nameOfEnum = Enum.GetName(typeof(EntityNames), name);
            var allFiles = new Dictionary<string, string>();

            foreach (var file in fileInDirectory)
            {
                //length of the array from the point until the end
                var extensionIndex = file.IndexOf('.') + 1;
                var extension = file.Substring(extensionIndex);

                if (file.Contains(nameOfEnum) && extension.Equals("json"))
                    allFiles.Add(file.Substring(file.IndexOf('_') + 1, 3), file.Substring(file.IndexOf('/') + 1));
            }

            return allFiles.ToDictionary(s => s.Key, s => ParseJsonToListOfObjects(s.Value));
        }

        public static T[] ParseJsonToListOfObjects(string name)
        {
            var fileLocation = Path.Combine(Paths.ProcessedDataFolder, name);

            var rootObject = JArray.Parse(File.ReadAllText(fileLocation));
            var objectList = rootObject.ToObject<T[]>();
            return objectList;
        }
    }
}