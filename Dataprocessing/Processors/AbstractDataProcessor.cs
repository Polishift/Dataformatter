using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json;

using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;


namespace Dataformatter.Dataprocessing.Processors
{
    public abstract class AbstractDataProcessor<I, O> where I : IModel
                                                      where O : IEntity
    {
        public abstract void SerializeDataToJson(List<I> rawModels);

        protected void WriteEntitiesToJson(string fileNamePrefix, IReadOnlyList<O> entities)
        {
            var orderedByCoutry = this.SortByCountry(entities);
            foreach (var countryPair in orderedByCoutry)
            {
                var resultFile = fileNamePrefix + countryPair.Key + ".json";

                if (!File.Exists(resultFile))
                    File.Create(resultFile).Dispose();

                using (var file = File.CreateText(resultFile))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(file, countryPair.Value);
                }
            }
        }

        private Dictionary<string, List<O>> SortByCountry(IReadOnlyList<O> allEntities)
        {
            var result = new Dictionary<string, List<O>>();
            for (var i = 0; i < allEntities.Count; i++)
            {
                var election = allEntities[i];

                if (!result.ContainsKey(election.CountryCode))
                    result.Add(election.CountryCode, new List<O>());

                result[election.CountryCode].Add(election);
            }
            return result;
        }
    }
}
