using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories;
using Newtonsoft.Json;

namespace Dataformatter.Dataprocessing.Processors
{
    class ElectionsProcessor : IDataProcessor<ConstituencyElectionModel>
    {
        public void SerializeDataToJson(List<ConstituencyElectionModel> rawModels)
        {
            AbstractElectionEntityFactory electionEntityFactory = new DefaultElectionEntityFactory();
            var electionsPerParty = new Dictionary<Tuple<string, int>, ElectionEntity>();

            for (var i = 0; i < rawModels.Count; i++)
            {
                var currentPartyAndYearCombination = new Tuple<string, int>(rawModels[i].PartyName, rawModels[i].Year);
                var currentRowCandidate = rawModels[i].CandidateName;

                if (electionsPerParty.ContainsKey(currentPartyAndYearCombination) == false)
                {
                    //As of yet undiscovered party/year combination
                    electionsPerParty.Add(currentPartyAndYearCombination, electionEntityFactory.Create(rawModels[i]));
                }
                else if (electionsPerParty[currentPartyAndYearCombination].PartyCandidates
                             .Contains(currentRowCandidate) == false)
                {
                    //Existing party/year combination, but undiscovered candidate
                    electionsPerParty[currentPartyAndYearCombination].PartyCandidates.Add(currentRowCandidate);
                }
            }

            WriteElectionEntitiesToJson(electionsPerParty.Values.ToList());
        }

        private static void WriteElectionEntitiesToJson(IReadOnlyList<ElectionEntity> entities)
        {
            var orderedByCoutry = SortByCountry(entities);
            foreach (var countryPair in orderedByCoutry)
            {
                var resultFile = "ProcessedData/Elections_" + countryPair.Key + ".json";

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

        private static Dictionary<string, List<ElectionEntity>> SortByCountry(IReadOnlyList<ElectionEntity> allElections)
        {
            var result = new Dictionary<string, List<ElectionEntity>>();
            for (var i = 0; i < allElections.Count; i++)
            {
                var election = allElections[i];
                if (!result.ContainsKey(election.CountryCode))
                    result.Add(election.CountryCode, new List<ElectionEntity>());
                result[election.CountryCode].Add(election);
            }
            return result;
        }
    }
}