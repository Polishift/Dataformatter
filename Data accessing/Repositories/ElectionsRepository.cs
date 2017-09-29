using System.Linq;
using Dataformatter.Dataprocessing.CsvParsing;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Repositories
{
    class ElectionsRepository : IRepository<ElectionEntity>
    {
        private const string FileName = "Election_NLD.json";

        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly ElectionEntity[] AllElections = JsonReader<ElectionEntity>.ParseJsonToListOfObjects(FileName);

        public ElectionEntity[] GetAll()
        {
            return AllElections; 
        }

        public ElectionEntity[] GetByCountry(string countryCode)
        {
            return AllElections.Where(e => e.CountryCode == countryCode).ToArray();
        }

        public ElectionEntity[] GetByYear(int year)
        {
            return AllElections.Where(e => e.Year == year).ToArray();
        }
    }
}