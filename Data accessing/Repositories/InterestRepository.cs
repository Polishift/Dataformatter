using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class InterestRepository : AbstractRepository<InterestEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly Dictionary<string, InterestEntity[]> AllInterestByCountry =
            JsonReader<InterestEntity>.ParseJsonToListOfObjects(EntityNames.Interest);

        public override InterestEntity[] GetAll()
        {
            var result = new List<InterestEntity>();
            foreach (var keyValuePair in AllInterestByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public override InterestEntity[] GetByCountry(string countryCode)
        {
            return GetFromDictionarySafely(countryCode, AllInterestByCountry);
        }

        public InterestEntity[] GetByYear(int year)
        {
            var result = new List<InterestEntity>();
            foreach (var keyValuePair in AllInterestByCountry)
                result.AddRange(keyValuePair.Value);
            return result.Where(e => e.Year == year).ToArray();
        }

        public List<string> GetCountryNames()
        {
            return AllInterestByCountry.Keys.ToList();
        }
    }
}