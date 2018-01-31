using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class PopulationRepository : AbstractRepository<PopulationEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly Dictionary<string, PopulationEntity[]> AllPopulationByCountry =
            JsonReader<PopulationEntity>.ParseJsonToListOfObjects(EntityNames.Population);

        public override PopulationEntity[] GetAll()
        {
            var result = new List<PopulationEntity>();
            foreach (var keyValuePair in AllPopulationByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public override PopulationEntity[] GetByCountry(string countryCode)
        {
            return base.GetFromDictionarySafely(countryCode, AllPopulationByCountry); 
        }

        public PopulationEntity[] GetByYear(int year)
        {
            var result = new List<PopulationEntity>();
            foreach (var keyValuePair in AllPopulationByCountry)
                result.AddRange(keyValuePair.Value);
            return result.Where(e => e.Year == year).ToArray();
        }

        public List<string> GetCountryNames()
        {
            return AllPopulationByCountry.Keys.ToList();
        }
    }
}