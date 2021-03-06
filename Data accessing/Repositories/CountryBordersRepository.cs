using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class CountryBordersRepository : AbstractRepository<CountryBordersEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        //Make sure this OVERWRITES, what is meant by thiss
        private static readonly Dictionary<string, CountryBordersEntity[]> AllBordersByCountry =
            JsonReader<CountryBordersEntity>.ParseJsonToListOfObjects(EntityNames.CountryBorders);

        public override CountryBordersEntity[] GetAll()
        {
            var result = new List<CountryBordersEntity>();
            foreach (var keyValuePair in AllBordersByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public override CountryBordersEntity[] GetByCountry(string countryCode)
        {
            return GetFromDictionarySafely(countryCode, AllBordersByCountry);
        }

        public List<string> GetCountryNames()
        {
            return AllBordersByCountry.Keys.ToList();
        }
    }
}