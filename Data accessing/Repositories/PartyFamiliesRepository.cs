using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class PartyFamiliesRepository : IRepository<PartyFamilyEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly Dictionary<string, PartyFamilyEntity[]> AllFamiliesByCountry =
            JsonReader<PartyFamilyEntity>.ParseJsonToListOfObjects(EntityNames.PartyFamilies);

        public PartyFamilyEntity[] GetAll()
        {
            var result = new List<PartyFamilyEntity>();
            foreach (var keyValuePair in AllFamiliesByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public PartyFamilyEntity[] GetByCountry(string countryCode)
        {
            return AllFamiliesByCountry[countryCode];
        }

        public static Dictionary<string, PartyFamilyEntity> GetDictionaryByCountry(string countryName)
        {
            if (AllFamiliesByCountry.ContainsKey(countryName))
            {
                var allClassificationsInGivenCountry = AllFamiliesByCountry[countryName];
                return allClassificationsInGivenCountry.ToDictionary(classificationEntity =>
                    classificationEntity.PartyName);
            }
            return new Dictionary<string, PartyFamilyEntity>();
        }

        public List<string> GetCountryNames()
        {
            return AllFamiliesByCountry.Keys.ToList();
        }
    }
}