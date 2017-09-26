using System;

using UnityEngine;

using Assets.Data.Repositories.Models;
using Assets.Dataprocessing.Entities;
using System.Linq;
using System.Collections.Generic;

namespace Assets.Data_accessing.Factories
{
    class DefaultElectionEntityFactory : AbstractElectionEntityFactory
    {
        private const int MISSING_VALUE_KEY = -990;

        public override ElectionEntity Create(ConstituencyElectionModel rawModel)
        {
            if(rawModel.PartyName.Equals("anti-revolutionaire partij"))
            {
                Debug.Log("ARP in " + rawModel.Year + " vf1: " + rawModel.VoteFraction + " vf2: " + rawModel.SecondRoundVoteFraction);
            }

            return new ElectionEntity
            {
                Year = rawModel.Year,
                CountryCode = CreateCountryCode(rawModel.CountryName),
                PartyClassification = "Unknown", //Where/How will we be doing this?
                PartyName = rawModel.PartyName,
                PartyCandidates = new HashSet<string>() { rawModel.CandidateName },
                TotalVotePercentage = GetFormattedTotalVotePercentage(rawModel.VoteFraction, rawModel.SecondRoundVoteFraction),
                TotalAmountOfSeatsGained = GetFormattedSeatsGained(rawModel.SeatsGained)
            };
        }

        private string CreateCountryCode(string FullCountryName) //maybe do this in a more central place?
        {
            return FullCountryName;
        }

        private double GetFormattedTotalVotePercentage(double rawVoteFraction, double rawSecondRoundVoteFraction)
        {
            if (rawVoteFraction == MISSING_VALUE_KEY)
                return rawSecondRoundVoteFraction;
            else
                return rawVoteFraction * 100;
        }

        private int GetFormattedSeatsGained(int rawSeatsGained)
        {
            if (rawSeatsGained == MISSING_VALUE_KEY)
                return 0;
            else
                return rawSeatsGained;
        }
    }
}
