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
        private DefaultElectionEntityFactory electionEntityFactory = new DefaultElectionEntityFactory();
        private Dictionary<Tuple<string, int>, ElectionEntity> ElectionsPerParty =
                                                               new Dictionary<Tuple<string, int>, ElectionEntity>();
        private Dictionary<string, int> SpecialPartyNamesAndAmount = new Dictionary<string, int>()
        {
            { "Independent", 0 },
            { "Blank", 0 }
        };


        public override void SerializeDataToJson(List<ConstituencyElectionModel> rawModels)
        {
            for (var i = 0; i < rawModels.Count; i++)
            {
                //Checking for independent/blank parties
                if (IsSpecialParty(rawModels[i]))
                    HandleSpecialPartyRow(rawModels[i]);
                else
                    HandleNormalPartyRow(rawModels[i]);
            }
            WriteEntitiesToJson(EntityNames.Election, ElectionsPerParty.Values.ToList());
        }

        private bool IsSpecialParty(ConstituencyElectionModel currentRawElectionModel)
        {
            return SpecialPartyNamesAndAmount.ContainsKey(currentRawElectionModel.PartyName);
        }

        private void HandleSpecialPartyRow(ConstituencyElectionModel currentRawElectionModel)
        {
            var currentRowPartyName = currentRawElectionModel.PartyName;

            SpecialPartyNamesAndAmount[currentRowPartyName] += 1;

            var artificialPartyName = currentRowPartyName + SpecialPartyNamesAndAmount[currentRowPartyName];
            var specialPartyAndYearCombination = new Tuple<string, int>(artificialPartyName, currentRawElectionModel.Year);

            ElectionsPerParty.Add(specialPartyAndYearCombination, electionEntityFactory.Create(currentRawElectionModel));
        }

        private void HandleNormalPartyRow(ConstituencyElectionModel currentRawElectionModel)
        {
            var currentPartyAndYearCombination = new Tuple<string, int>(currentRawElectionModel.PartyName, 
                                                                        currentRawElectionModel.Year);
            var currentRowCandidate = currentRawElectionModel.CandidateName;

            if (ElectionsPerParty.ContainsKey(currentPartyAndYearCombination) == false)
            {
                //As of yet undiscovered party/year combination 
                ElectionsPerParty.Add(currentPartyAndYearCombination, electionEntityFactory.Create(currentRawElectionModel));
            }
            else if (ElectionsPerParty[currentPartyAndYearCombination].PartyCandidates
                     .Contains(currentRowCandidate) == false)
            {
                //Existing party/year combination, but undiscovered candidate
                ElectionsPerParty[currentPartyAndYearCombination].PartyCandidates.Add(currentRowCandidate);
            }
        }
    }
}