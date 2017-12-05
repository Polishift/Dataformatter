using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class WarRepository : IRepository<WarEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly Dictionary<string, WarEntity[]> AllWarByCountry =
            JsonReader<WarEntity>.ParseJsonToListOfObjects(EntityNames.War);

        public WarEntity[] GetAll()
        {
            var result = new List<WarEntity>();
            foreach (var keyValuePair in AllWarByCountry)
            {
                result.AddRange(keyValuePair.Value);
            }
            return result.ToArray();
        }

        public WarEntity[] GetByCountry(string countryCode)
        {
            return AllWarByCountry[countryCode];
        }

        public WarEntity[] GetByYear(int year)
        {
            var result = new List<WarEntity>();
            foreach (var keyValuePair in AllWarByCountry)
            {
                result.AddRange(keyValuePair.Value);
            }
            return result.Where(e => e.StartYear <= year && e.EndYear >= year).ToArray();
        }

        public List<string> GetCountryNames()
        {
            return AllWarByCountry.Keys.ToList();
        }
    }
}