using System.Collections.Generic;
using System.IO;
using Dataformatter.Datamodels;
using Dataformatter.Data_accessing.Factories.ModelFactories;
using Newtonsoft.Json.Linq;

namespace Dataformatter.Dataprocessing.CsvParsing
{
    public class JsonToModel<T> where T : IModel
    {
        public static List<T> ParseJsonToModel(string fileLocation, IJsonModelFactory<T> modelFactory)
        {
            var result = new List<T>();
            var rootObject = JObject.Parse(File.ReadAllText(fileLocation));
            result.Add(modelFactory.Create(rootObject));
            return result;
        }
    }
}