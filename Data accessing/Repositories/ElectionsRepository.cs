using System.Linq;
using Dataformatter.Dataprocessing.CsvParsing;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Repositories
{
    class ElectionsRepository : IRepository<ElectionEntity>
    {
        private const string FILE_LOCATION = "Data/Processed/Elections.json";

        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static ElectionEntity[] allElections = JsonReader<ElectionEntity>.ParseJsonToListOfObjects(FILE_LOCATION);

        public ElectionEntity[] GetAll()
        {
            return allElections; 
        }

        public ElectionEntity[] GetByCountry(string CountryCode)
        {
            return allElections.Where(e => e.CountryCode == CountryCode).ToArray();
        }

        public ElectionEntity[] GetByYear(int year)
        {
            return allElections.Where(e => e.Year == year).ToArray();
        }
    }
}