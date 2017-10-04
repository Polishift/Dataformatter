using System;
using System.IO;
using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Data_accessing.Factories.ModelFactories;
using Newtonsoft.Json.Linq;

namespace Dataformatter.Dataprocessing.CsvParsing
{
    public static class JsonToModel<T> where T : IModel
    {
        public static List<T> ParseJsonDirectoryToModels(string directoryPath, IJsonModelFactory<T> modelFactory, string pattern = "*.json")
        {
            string[] filesInDirectory = Directory.GetFiles(directoryPath, pattern, SearchOption.AllDirectories);

            var resultList = new List<T>();
            for (int i = 0; i < filesInDirectory.Length; i++)
            {
                var currentFile = filesInDirectory[i];

                var currentFileModels = ParseJsonFileToModel(currentFile, modelFactory);
                currentFileModels.ForEach(m => resultList.Add(m));                
            }
            Console.WriteLine("resultList.count =" + resultList.Count);
            return resultList;
        }
        
        public static List<T> ParseJsonFileToModel(string fileLocation, IJsonModelFactory<T> modelFactory)
        {
            var result = new List<T>();

            var rootObject = JObject.Parse(File.ReadAllText(fileLocation));
            result.Add(modelFactory.Create(rootObject));

            return result;
        }
    }
}