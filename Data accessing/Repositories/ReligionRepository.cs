using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class ReligionRepository : IRepository<PartyClassificationEntity>
    {
        private static readonly Dictionary<string, PartyClassificationEntity[]> AllReligionByCountry =
            JsonReader<PartyClassificationEntity>.ParseJsonToListOfObjects(EntityNames.Religion);

        public PartyClassificationEntity[] GetAll()
        {
            var result = new List<PartyClassificationEntity>();
            foreach (var keyValuePair in AllReligionByCountry)
            {
                result.AddRange(keyValuePair.Value);
            }
            return result.ToArray();
        }

        public PartyClassificationEntity[] GetByCountry(string countryCode)
        {
            return AllReligionByCountry[countryCode];
        }
        
        public static IEnumerable<string> GetCountryNames()
        {
            return AllReligionByCountry.Keys.ToList();
        }
    }
}