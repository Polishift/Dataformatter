using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class TvRepository : AbstractRepository<TvEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly Dictionary<string, TvEntity[]> AllTvByCountry =
            JsonReader<TvEntity>.ParseJsonToListOfObjects(EntityNames.Tv);

        public override TvEntity[] GetAll()
        {
            var result = new List<TvEntity>();
            foreach (var keyValuePair in AllTvByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public override TvEntity[] GetByCountry(string countryCode)
        {
            return GetFromDictionarySafely(countryCode, AllTvByCountry);
        }

        public TvEntity[] GetByYear(int year)
        {
            var result = new List<TvEntity>();
            foreach (var keyValuePair in AllTvByCountry)
                result.AddRange(keyValuePair.Value);
            return result.Where(e => e.Year == year).ToArray();
        }

        public List<string> GetCountryNames()
        {
            return AllTvByCountry.Keys.ToList();
        }
    }
}