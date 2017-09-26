using System.IO;
using Newtonsoft.Json.Linq;

namespace Dataformatter.Dataprocessing.CsvParsing
{
    public static class JsonReader<T>
    {
        public static T[] ParseJsonToListOfObjects(string fileLocation)
        {
            var rootObject = JObject.Parse(File.ReadAllText(fileLocation));
            var rootArray = (JArray) rootObject[""];

            var objectList = rootArray.ToObject<T[]>();
            return objectList;
        }
    }
}
