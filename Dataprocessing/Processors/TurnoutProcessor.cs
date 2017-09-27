using System.Collections.Generic;
using System.IO;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories;
using Newtonsoft.Json;

namespace Dataformatter.Dataprocessing.Processors
{
    public class TurnoutProcessor :IDataProcessor<TurnoutModel>
    {
        public void SerializeDataToJson(List<TurnoutModel> rawModels)
        {
            var turnoutEntities = new List<TurnoutEntity>();
            var entityFactory = new DefaultTurnoutEntityFactory();
            
            for (var i = 0; i < rawModels.Count; i++)
            {
                turnoutEntities.Add(entityFactory.Create(rawModels[i]));
            }
            WriteTurnoutEntitiesToJson(turnoutEntities);   
        }
        
        private static void WriteTurnoutEntitiesToJson(IReadOnlyList<TurnoutEntity> entities)
        {
            var orderedByCoutry = SortByCountry(entities);
            foreach (var countryPair in orderedByCoutry)
            {
                //todo make this generic for all files. To prevent errors and eventually hacks (:
                var countryName = countryPair.Key.Replace("/", "_");
                var resultFile = "ProcessedData/turnout_" + countryName+ ".json";

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
        private static Dictionary<string, List<TurnoutEntity>> SortByCountry(
            IReadOnlyList<TurnoutEntity> allElections)
        {
            var result = new Dictionary<string, List<TurnoutEntity>>();
            for (var i = 0; i < allElections.Count; i++)
            {
                var election = allElections[i];
                if (!result.ContainsKey(election.CountryCode))
                    result.Add(election.CountryCode, new List<TurnoutEntity>());
                result[election.CountryCode].Add(election);
            }
            return result;
        }
    }
}