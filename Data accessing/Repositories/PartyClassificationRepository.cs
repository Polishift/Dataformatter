using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class PartyClassificationRepository : AbstractRepository<PartyClassificationEntity>
    {
        private static readonly Dictionary<string, PartyClassificationEntity[]> AllPartyClassificationsByCountry =
            JsonReader<PartyClassificationEntity>.ParseJsonToListOfObjects(EntityNames.PartyClassification);

        public override PartyClassificationEntity[] GetAll()
        {
            var result = new List<PartyClassificationEntity>();
            foreach (var keyValuePair in AllPartyClassificationsByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public override PartyClassificationEntity[] GetByCountry(string countryCode)
        {
            return GetFromDictionarySafely(countryCode, AllPartyClassificationsByCountry);
        }

        public static IEnumerable<string> GetCountryNames()
        {
            return AllPartyClassificationsByCountry.Keys.ToList();
        }
    }
}