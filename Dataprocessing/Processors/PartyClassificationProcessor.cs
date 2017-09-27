using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories;
using Dataformatter.Data_accessing.Factories.EntityFactories;
using Newtonsoft.Json;

namespace Dataformatter.Dataprocessing.Processors
{
    class PartyClassificationProcessor : IDataProcessor<PartyClassificationModel>
    {
        public void SerializeDataToJson(List<PartyClassificationModel> rawModels)
        {
            var entityFactory = new DefaultPartyClassificationEntityFactory();
            var classificationPerParty = new Dictionary<int, PartyClassificationEntity>();

            for (var i = 0; i < rawModels.Count; i++)
            {
                var model = rawModels[i];
                if (classificationPerParty.ContainsKey(model.Id))
                    continue;

                classificationPerParty.Add(model.Id, entityFactory.Create(model));
            }

            WritePartyClassificationEntitiesToJson(classificationPerParty.Values.ToList());
        }

        private static void WritePartyClassificationEntitiesToJson(IReadOnlyList<PartyClassificationEntity> entities)
        {
            var orderedByCoutry = SortByCountry(entities);
            foreach (var countryPair in orderedByCoutry)
            {
                var resultFile = "ProcessedData/PartyClassification_" + countryPair.Key + ".json";

                if (!File.Exists(resultFile))
                    using (File.Create(resultFile))
                    {
                    }
                using (var file = File.CreateText(resultFile))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(file, countryPair.Value);
                }
            }
        }

        //todo add this to helper functions to make it more generic
        private static Dictionary<string, List<PartyClassificationEntity>> SortByCountry(
            IReadOnlyList<PartyClassificationEntity> allElections)
        {
            var result = new Dictionary<string, List<PartyClassificationEntity>>();
            for (var i = 0; i < allElections.Count; i++)
            {
                var election = allElections[i];
                if (!result.ContainsKey(election.CountryCode))
                    result.Add(election.CountryCode, new List<PartyClassificationEntity>());
                result[election.CountryCode].Add(election);
            }
            return result;
        }
    }
}