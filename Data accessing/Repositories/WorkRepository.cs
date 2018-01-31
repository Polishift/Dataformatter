using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class WorkRepository : AbstractRepository<WorkEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly Dictionary<string, WorkEntity[]> AllWorkByCountry =
            JsonReader<WorkEntity>.ParseJsonToListOfObjects(EntityNames.Work);

        public override WorkEntity[] GetAll()
        {
            var result = new List<WorkEntity>();
            foreach (var keyValuePair in AllWorkByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public override WorkEntity[] GetByCountry(string countryCode)
        {
            return GetFromDictionarySafely(countryCode, AllWorkByCountry);
        }

        public WorkEntity[] GetByYear(int year)
        {
            var result = new List<WorkEntity>();
            foreach (var keyValuePair in AllWorkByCountry)
                result.AddRange(keyValuePair.Value);
            return result.Where(e => e.Year == year).ToArray();
        }

        public List<string> GetCountryNames()
        {
            return AllWorkByCountry.Keys.ToList();
        }
    }
}