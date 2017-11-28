﻿using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class PartyClassificationRepository : IRepository<PartyClassificationEntity>
    {
        private static readonly Dictionary<string, PartyClassificationEntity[]> AllPartyClassificationsByCountry =
            JsonReader<PartyClassificationEntity>.ParseJsonToListOfObjects(EntityNames.PartyClassification);

        public PartyClassificationEntity[] GetAll()
        {
            var result = new List<PartyClassificationEntity>();
            foreach (var keyValuePair in AllPartyClassificationsByCountry)
            {
                result.AddRange(keyValuePair.Value);
            }
            return result.ToArray();
        }

        public PartyClassificationEntity[] GetByCountry(string countryCode)
        {
            return AllPartyClassificationsByCountry[countryCode];
        }
        
        public static IEnumerable<string> GetCountryNames()
        {
            return AllPartyClassificationsByCountry.Keys.ToList();
        }
    }
}