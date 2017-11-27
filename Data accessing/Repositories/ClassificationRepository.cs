using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class ClassificationRepository : IRepository<ClassificationEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly Dictionary<string, ClassificationEntity[]> AllClassificationsByCountry =
            JsonReader<ClassificationEntity>.ParseJsonToListOfObjects(EntityNames.PartyFamilies );

        public ClassificationEntity[] GetAll()
        {
            var result = new List<ClassificationEntity>();
            foreach (var keyValuePair in AllClassificationsByCountry)
            {
                result.AddRange(keyValuePair.Value);
            }
            return result.ToArray();    
        }

        public Dictionary<string, ClassificationEntity> GetDictionaryByCountry(string name)
        {
            if (AllClassificationsByCountry.ContainsKey(name))
            {
                var all = AllClassificationsByCountry[name];
                return all.ToDictionary(classificationEntity => classificationEntity.PartyName);
            }
            return new Dictionary<string, ClassificationEntity>();
        }

        public ClassificationEntity[] GetByCountry(string countryCode)
        {
                return AllClassificationsByCountry[countryCode];   
        }
        
        public List<string> GetCountryNames()
        {
            return AllClassificationsByCountry.Keys.ToList();
        }
    }
}