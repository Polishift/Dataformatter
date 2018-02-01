using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class ReligionRepository : AbstractRepository<ReligionEntity>
    {
        private static readonly Dictionary<string, ReligionEntity[]> AllReligionByCountry =
            JsonReader<ReligionEntity>.ParseJsonToListOfObjects(EntityNames.Religion);

        public override ReligionEntity[] GetAll()
        {
            var result = new List<ReligionEntity>();
            foreach (var keyValuePair in AllReligionByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public override ReligionEntity[] GetByCountry(string countryCode)
        {
            return GetFromDictionarySafely(countryCode, AllReligionByCountry);
        }

        public static IEnumerable<string> GetCountryNames()
        {
            return AllReligionByCountry.Keys.ToList();
        }
    }
}