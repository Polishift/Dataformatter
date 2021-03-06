﻿using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class GdpTotalRepository : AbstractRepository<GdpTotalEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly Dictionary<string, GdpTotalEntity[]> AllGdpByCountry =
            JsonReader<GdpTotalEntity>.ParseJsonToListOfObjects(EntityNames.GdpTotal);

        public override GdpTotalEntity[] GetAll()
        {
            var result = new List<GdpTotalEntity>();
            foreach (var keyValuePair in AllGdpByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public override GdpTotalEntity[] GetByCountry(string countryCode)
        {
            return GetFromDictionarySafely(countryCode, AllGdpByCountry);
        }

        public GdpTotalEntity[] GetByYear(int year)
        {
            var result = new List<GdpTotalEntity>();
            foreach (var keyValuePair in AllGdpByCountry)
                result.AddRange(keyValuePair.Value);
            return result.Where(e => e.Year == year).ToArray();
        }

        public List<string> GetCountryNames()
        {
            return AllGdpByCountry.Keys.ToList();
        }
    }
}