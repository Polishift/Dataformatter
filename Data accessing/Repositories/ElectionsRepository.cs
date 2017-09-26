using System.Linq;
using Dataformatter.Dataprocessing.CsvParsing;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Repositories
{
    class ElectionsRepository : IRepository<ElectionEntity>
    {
        private const string FileLocation = "Data/Processed/Elections.json";

        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static ElectionEntity[] allElections = JsonReader<ElectionEntity>.ParseJsonToListOfObjects(FileLocation);

        public ElectionEntity[] GetAll()
        {
            return allElections; 
        }

        public ElectionEntity[] GetByCountry(string countryCode)
        {
            return allElections.Where(e => e.CountryCode == countryCode).ToArray();
        }

        public ElectionEntity[] GetByYear(int year)
        {
            return allElections.Where(e => e.Year == year).ToArray();
        }
    }
}