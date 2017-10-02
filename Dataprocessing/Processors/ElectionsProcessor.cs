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
        private HashSet<string> KnownConstituencies = new HashSet<string>();
        private Dictionary<Tuple<string, int>, int> TotalAmountOfVotesPerCountryAndYear =
                                                               new Dictionary<Tuple<string, int>, int>();
        private Dictionary<Tuple<string, int>, ElectionEntity> ElectionsPerParty =
                                                              new Dictionary<Tuple<string, int>, ElectionEntity>();
        private Dictionary<string, int> SpecialPartyNamesAndAmount = new Dictionary<string, int>()
        {
            { "Independent", 0 },
            { "independent", 0},
            { "Independents", 0},
            { "Blank", 0 }
        };


        public override void SerializeDataToJson(List<ConstituencyElectionModel> rawModels)
        {
            int previousRowsYear = int.MinValue;
            int currentRowsYear = int.MinValue;

            for (var i = 0; i < rawModels.Count; i++)
            {
                currentRowsYear = rawModels[i].Year;

                //Checking for independent/blank parties
                if (IsSpecialParty(rawModels[i]))
                {
                    var artificialPartyName = GetArtificalPartyName(rawModels[i]);
                    rawModels[i].PartyName = artificialPartyName;
                }
                HandlePartyRow(rawModels[i]);

                AddCurrentConstituencyVotesToTotal(rawModels[i]);
                SumConstituencyPartyVotes(rawModels[i]);

                //Known constituencies are used to ensure that the summation of all votes is only done once per constituency, per election.
                EmptyKnownConstituenciesEachYear(previousRowsYear, currentRowsYear);

                previousRowsYear = rawModels[i].Year;
            }
            //Calculating actual vote percentages
            CalculateVotePercentages();

            WriteEntitiesToJson(EntityNames.Election, ElectionsPerParty.Values.ToList());
        }


        private bool IsSpecialParty(ConstituencyElectionModel currentRawElectionModel)
        {
            return SpecialPartyNamesAndAmount.ContainsKey(currentRawElectionModel.PartyName);
        }

        private string GetArtificalPartyName(ConstituencyElectionModel currentRawElectionModel)
        {
            var currentRowPartyName = currentRawElectionModel.PartyName;
            SpecialPartyNamesAndAmount[currentRowPartyName] += 1;

            return currentRowPartyName + " " + SpecialPartyNamesAndAmount[currentRowPartyName];
        }


        private void HandlePartyRow(ConstituencyElectionModel currentRawElectionModel)
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




        private void AddCurrentConstituencyVotesToTotal(ConstituencyElectionModel currentRawElectionModel)
        {
            var currentConstituency = currentRawElectionModel.ConstituencyName;

            if (KnownConstituencies.Contains(currentConstituency) == false)
            {
                KnownConstituencies.Add(currentConstituency);

                var currentCountryAndYearCombination = new Tuple<string, int>(currentRawElectionModel.CountryName,
                                                                          currentRawElectionModel.Year);

                if (TotalAmountOfVotesPerCountryAndYear.ContainsKey(currentCountryAndYearCombination))
                    TotalAmountOfVotesPerCountryAndYear[currentCountryAndYearCombination] += currentRawElectionModel.TotalAmountOfVotes;
                else
                    TotalAmountOfVotesPerCountryAndYear.Add(currentCountryAndYearCombination, currentRawElectionModel.TotalAmountOfVotes);

                //do second round?
            }
        }

        private void SumConstituencyPartyVotes(ConstituencyElectionModel currentRawElectionModel)
        {
            var currentPartyAndYearCombination = new Tuple<string, int>(currentRawElectionModel.PartyName,
                                                                        currentRawElectionModel.Year);

            ElectionsPerParty[currentPartyAndYearCombination].TotalAmountOfVotes += (int)currentRawElectionModel.AmountOfPartyVotes;
            //do second round?
        }

        private void EmptyKnownConstituenciesEachYear(int previousRowsYear, int currentRowsYear) //if previous year is greater
        {
            if (currentRowsYear > previousRowsYear)
                KnownConstituencies.Clear();
        }




        private void CalculateVotePercentages()
        {
            foreach (var partyElectionResult in ElectionsPerParty)
            {
                var currentElectionKey = partyElectionResult.Key;
                var currentCountry = partyElectionResult.Value.CountryName;
                var currentYear = partyElectionResult.Key.Item2;
                var currentCountryAndYear = new Tuple<string, int>(currentCountry, currentYear);

                double TotalAmountOfVotesInCountry = TotalAmountOfVotesPerCountryAndYear[currentCountryAndYear];
                double AmountOfVotesForCurrentParty = partyElectionResult.Value.TotalAmountOfVotes;

                if (TotalAmountOfVotesInCountry > 0) //This ocassionally happens with seat-based elections like Andorra's
                {
                    ElectionsPerParty[currentElectionKey].TotalVotePercentage = (AmountOfVotesForCurrentParty / TotalAmountOfVotesInCountry) * 100;
                }
            }
        }
    }
}