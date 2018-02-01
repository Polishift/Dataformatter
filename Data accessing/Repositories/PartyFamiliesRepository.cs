using System;
using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class PartyFamiliesRepository : AbstractRepository<PartyFamilyEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly Dictionary<string, PartyFamilyEntity[]> AllFamiliesByCountry =
            JsonReader<PartyFamilyEntity>.ParseJsonToListOfObjects(EntityNames.PartyFamilies);

        public override PartyFamilyEntity[] GetAll()
        {
            var result = new List<PartyFamilyEntity>();
            foreach (var keyValuePair in AllFamiliesByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public override PartyFamilyEntity[] GetByCountry(string countryCode)
        {
            return GetFromDictionarySafely(countryCode, AllFamiliesByCountry);
        }

        public static Dictionary<string, PartyFamilyEntity> GetDictionaryByCountry(string countryName)
        {
            Console.WriteLine(AllFamiliesByCountry.Count);
            if (AllFamiliesByCountry.ContainsKey(countryName))
            {
                Console.WriteLine(AllFamiliesByCountry[countryName].Length);
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