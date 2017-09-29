using System.IO;
using Newtonsoft.Json.Linq;

namespace Dataformatter.Dataprocessing.CsvParsing
{
    public static class JsonReader<T>
    {
        public static T[] ParseJsonToListOfObjects(string fileName)
        {
            var fileLocation = "ProcessedData/" + fileName;
            var rootObject = JArray.Parse(File.ReadAllText(fileLocation));
            var objectList = rootObject.ToObject<T[]>();
            return objectList;
        }
    }
}
