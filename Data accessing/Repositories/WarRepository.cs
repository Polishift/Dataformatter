using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class WarRepository : AbstractRepository<WarEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly Dictionary<string, WarEntity[]> AllWarByCountry =
            JsonReader<WarEntity>.ParseJsonToListOfObjects(EntityNames.War);

        public override WarEntity[] GetAll()
        {
            var result = new List<WarEntity>();
            foreach (var keyValuePair in AllWarByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public override WarEntity[] GetByCountry(string countryCode)
        {
            return base.GetFromDictionarySafely(countryCode, AllWarByCountry); 
        }

        public WarEntity[] GetByYear(int year)
        {
            var result = new List<WarEntity>();
            foreach (var keyValuePair in AllWarByCountry)
                result.AddRange(keyValuePair.Value);
            return result.Where(e => e.StartYear <= year && e.EndYear >= year).ToArray();
        }

        public List<string> GetCountryNames()
        {
            return AllWarByCountry.Keys.ToList();
        }
    }
}