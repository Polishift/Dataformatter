using System.IO;
using Newtonsoft.Json.Linq;

namespace Dataformatter.Dataprocessing.CsvParsing
{
    public static class JsonReader<T>
    {
        public static T[] ParseJsonToListOfObjects(string fileLocation)
        {
            JObject rootObject = JObject.Parse(File.ReadAllText(fileLocation));
            JArray rootArray = (JArray) rootObject[""];

            T[] objectList = rootArray.ToObject<T[]>();
            return objectList;
        }
    }
}
