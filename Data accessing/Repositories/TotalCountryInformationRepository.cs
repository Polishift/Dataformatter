using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class TotalCountryInformationRepository : IRepository<TotalCountryInformationEntity>
    {
        private static readonly Dictionary<string, TotalCountryInformationEntity[]> AllReligionByCountry =
            JsonReader<TotalCountryInformationEntity>.ParseJsonToListOfObjects(EntityNames.TotalCountryInformationEntities);

        public TotalCountryInformationEntity[] GetAll()
        {
            var result = new List<TotalCountryInformationEntity>();
            foreach (var keyValuePair in AllReligionByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public TotalCountryInformationEntity[] GetByCountry(string countryCode)
        {
            return AllReligionByCountry[countryCode];
        }

        public static IEnumerable<string> GetCountryNames()
        {
            return AllReligionByCountry.Keys.ToList();
        }
    }
}