using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class GdpPerCapitaRepository : AbstractRepository<GdpPerCapitaEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly Dictionary<string, GdpPerCapitaEntity[]> AllGdpByCountry =
            JsonReader<GdpPerCapitaEntity>.ParseJsonToListOfObjects(EntityNames.GdpPerCapita);

        public override GdpPerCapitaEntity[] GetAll()
        {
            var result = new List<GdpPerCapitaEntity>();
            foreach (var keyValuePair in AllGdpByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public override GdpPerCapitaEntity[] GetByCountry(string countryCode)
        {
            return GetFromDictionarySafely(countryCode, AllGdpByCountry);
        }

        public GdpPerCapitaEntity[] GetByYear(int year)
        {
            var result = new List<GdpPerCapitaEntity>();
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