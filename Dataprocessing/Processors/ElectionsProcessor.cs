using System;
using System.Collections.Generic;
using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories.EntityFactories;

namespace Dataformatter.Dataprocessing.Processors
{
    class ElectionsProcessor : AbstractDataProcessor<ConstituencyElectionModel,
        ElectionEntity>
    {
        

        public override void SerializeDataToJson(List<ConstituencyElectionModel> rawModels)
        {
            var electionEntityFactory = new DefaultElectionEntityFactory();
            var electionsPerParty = new Dictionary<Tuple<string, int>, ElectionEntity>();

            for (var i = 0; i < rawModels.Count; i++)
            {
                var currentPartyAndYearCombination = new Tuple<string, int>(rawModels[i].PartyName, rawModels[i].Year);
                var currentRowCandidate = rawModels[i].CandidateName;
                var currentRowPartyName = rawModels[i].PartyName;

                if (electionsPerParty.ContainsKey(currentPartyAndYearCombination) == false )
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
            WriteEntitiesToJson(EntityNames.Election, electionsPerParty.Values.ToList());
        }
    }
}