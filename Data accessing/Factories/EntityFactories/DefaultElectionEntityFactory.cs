using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    class DefaultElectionEntityFactory : EntityFactory
    {
        private const int MissingValueKey = -990;

        public ElectionEntity Create(ConstituencyElectionModel rawModel)
        {
            return new ElectionEntity
            {
                Year = rawModel.Year,
                CountryCode = CreateCountryCode(rawModel.CountryName),
                PartyClassification = "Unknown", //Where/How will we be doing this?
                PartyName = rawModel.PartyName,
                PartyCandidates = new HashSet<string> { rawModel.CandidateName },
                TotalVotePercentage =
                    GetFormattedTotalVotePercentage(rawModel.VoteFraction, rawModel.SecondRoundVoteFraction),
                TotalAmountOfSeatsGained = GetFormattedSeatsGained(rawModel.SeatsGained)
            };
        }

        private static double GetFormattedTotalVotePercentage(double rawVoteFraction, double rawSecondRoundVoteFraction)
        {
            if (rawVoteFraction == MissingValueKey)
                return rawSecondRoundVoteFraction;
            return rawVoteFraction * 100;
        }

        private static int GetFormattedSeatsGained(int rawSeatsGained)
        {
            if (rawSeatsGained == MissingValueKey)
                return 0;
            return rawSeatsGained;
        }
    }
}