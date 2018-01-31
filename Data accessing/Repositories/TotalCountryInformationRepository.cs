using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class TotalCountryInformationRepository : AbstractRepository<TotalCountryInformationEntity>
    {
        private static readonly Dictionary<string, TotalCountryInformationEntity[]> AllInfoByCountry =
            JsonReader<TotalCountryInformationEntity>.ParseJsonToListOfObjects(EntityNames.TotalCountryInformationEntities);

        public override TotalCountryInformationEntity[] GetAll()
        {
            var result = new List<TotalCountryInformationEntity>();
            foreach (var keyValuePair in AllInfoByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public override TotalCountryInformationEntity[] GetByCountry(string countryCode)
        {
            return AllInfoByCountry[countryCode];
        }

        public static IEnumerable<string> GetCountryNames()
        {
            return AllInfoByCountry.Keys.ToList();
        }
    }
}