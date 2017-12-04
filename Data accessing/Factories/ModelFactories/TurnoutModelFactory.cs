using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;
using Dataformatter.Misc;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class TurnoutModelFactory : ICsvModelFactory<TurnoutModel>
    {
        private const int InvalidVotesColumnIndex = 9;
        private const int CountryColumnIndex = 0;
        private const int PopulationColumnIndex = 8;
        private const int RegistrationColumnIndex = 5;
        private const int TotalVotesColumnIndex = 4;
        private const int TypeColumnIndex = 1;
        private const int VapTurnoutColumnIndex = 6;
        private const int VoterTurnoutColumnIndex = 3;
        private const int VotingAgeColumnIndex = 7;
        private const int YearColumnIndex = 2;

        public TurnoutModel Create(List<string> csvDataRow)
        {
            return new TurnoutModel
            {
                InvalidVotes = double.Parse(HelperFunctions.StripOnSpaces(csvDataRow[InvalidVotesColumnIndex]),
                    CultureInfo.InvariantCulture),
                CountryName = csvDataRow[CountryColumnIndex],
                Population = int.Parse(HelperFunctions.ReplaceCommasInThousands(csvDataRow[PopulationColumnIndex]),
                    CultureInfo.InvariantCulture),
                Registration = int.Parse(HelperFunctions.ReplaceCommasInThousands(csvDataRow[RegistrationColumnIndex]),
                    CultureInfo.InvariantCulture),
                TotalVotes = int.Parse(HelperFunctions.ReplaceCommasInThousands(csvDataRow[TotalVotesColumnIndex]),
                    CultureInfo.InvariantCulture),
                Type = csvDataRow[TypeColumnIndex],
                VapTurnout =
                    double.Parse(HelperFunctions.StripOnSpaces(csvDataRow[VapTurnoutColumnIndex]), CultureInfo.InvariantCulture),
                VoterTurnout = double.Parse(HelperFunctions.StripOnSpaces(csvDataRow[VoterTurnoutColumnIndex]),
                    CultureInfo.InvariantCulture),
                VotingAge = int.Parse(HelperFunctions.ReplaceCommasInThousands(csvDataRow[VotingAgeColumnIndex]),
                    CultureInfo.InvariantCulture),
                Year = int.Parse(csvDataRow[YearColumnIndex], CultureInfo.InvariantCulture)
            };

        }

       
    }
}