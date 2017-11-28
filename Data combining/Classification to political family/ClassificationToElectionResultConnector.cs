using System;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_combining.Classification_to_political_family
{
    public class ClassificationToElectionResultConnector
    {
        private readonly PartyClassificationEntity[] _toBeConnectedClassificationEntitiesForCurrentCountry;

        public ClassificationToElectionResultConnector(PartyClassificationEntity[] toBeConnectedClassificationEntitiesForCurrentCountry)
        {
            _toBeConnectedClassificationEntitiesForCurrentCountry = toBeConnectedClassificationEntitiesForCurrentCountry;
        }


        public ElectionEntity Connect(ElectionEntity electionResultForParty)
        {
            foreach (var partyClassificationEntity in _toBeConnectedClassificationEntitiesForCurrentCountry)
            {
                if (partyClassificationEntity.Name.Equals(electionResultForParty.PartyAbbreviation, StringComparison.CurrentCultureIgnoreCase))
                {
                    //We have found a classification Entity whose abrevviations equals that of the electionsResultForParty's newly made abrevviation.
                    Console.WriteLine("Matched classification with party abrevviation " + partyClassificationEntity.Name + " to an election result for a party with (newly made) abrevviation " + electionResultForParty.PartyAbbreviation + ". Full party name: " + electionResultForParty.PartyName + ", their newly associated classification is: " + partyClassificationEntity.Classification);

                    //Now that we have a classification abrev match to (newly made) election result for party abrev, that election results party's classification can be set! :)
                    electionResultForParty.PartyClassification = partyClassificationEntity.Classification;


                    PartyClassificationAndElectionsMerger.PoliticalFamilyPerPartyInCurrentCountry[electionResultForParty.PartyName].Classification = partyClassificationEntity.Classification;


                    break;
                }
            }
            return electionResultForParty;
        }


        public bool WasConnectingSuccesfull(ElectionEntity electionResultForParty)
        {
            return !electionResultForParty.PartyClassification.Equals("Unknown") && !electionResultForParty.PartyClassification.Equals("null");
        }
    }
}