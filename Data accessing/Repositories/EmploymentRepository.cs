using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class EmplotymentRepository : IRepository<EmploymentEntity>
    {
        private static readonly Dictionary<string, EmploymentEntity[]> AllEmploymentsByCountry =
            JsonReader<EmploymentEntity>.ParseJsonToListOfObjects(EntityNames.Employment);

        public EmploymentEntity[] GetAll()
        {
            var result = new List<EmploymentEntity>();
            foreach (var keyValuePair in AllEmploymentsByCountry)
            {
                result.AddRange(keyValuePair.Value);
            }
            return result.ToArray();
        }

        public EmploymentEntity[] GetByCountry(string countryCode)
        {
            return AllEmploymentsByCountry[countryCode];
        }
        
        public static IEnumerable<string> GetCountryNames()
        {
            return AllEmploymentsByCountry.Keys.ToList();
        }
    }
}