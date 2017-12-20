using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class WorkRepository : IRepository<WorkEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly Dictionary<string, WorkEntity[]> AllWorkByCountry =
            JsonReader<WorkEntity>.ParseJsonToListOfObjects(EntityNames.Work);

        public WorkEntity[] GetAll()
        {
            var result = new List<WorkEntity>();
            foreach (var keyValuePair in AllWorkByCountry)
            {
                result.AddRange(keyValuePair.Value);
            }
            return result.ToArray();
        }

        public WorkEntity[] GetByCountry(string countryCode)
        {
            return AllWorkByCountry[countryCode];
        }

        public WorkEntity[] GetByYear(int year)
        {
            var result = new List<WorkEntity>();
            foreach (var keyValuePair in AllWorkByCountry)
            {
                result.AddRange(keyValuePair.Value);
            }
            return result.Where(e => e.Year == year).ToArray();
        }

        public List<string> GetCountryNames()
        {
            return AllWorkByCountry.Keys.ToList();
        }
    }
    
}