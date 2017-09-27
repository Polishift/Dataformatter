using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories
{
    public class TurnoutModelFactory : IModelFactory<TurnoutModel>
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
            var result = new TurnoutModel();

            result.InvalidVotes = double.Parse(StripOnSpaces(csvDataRow[InvalidVotesColumnIndex]),
                CultureInfo.InvariantCulture);
            result.CountryName = csvDataRow[CountryColumnIndex];
            result.Population =
                int.Parse(ReplaceCommasInThousands(csvDataRow[PopulationColumnIndex]),
                    CultureInfo.InvariantCulture);
            result.Registration = int.Parse(ReplaceCommasInThousands(csvDataRow[RegistrationColumnIndex]),
                CultureInfo.InvariantCulture);
            result.TotalVotes =
                int.Parse(ReplaceCommasInThousands(csvDataRow[TotalVotesColumnIndex]), CultureInfo.InvariantCulture);
            result.Type = csvDataRow[TypeColumnIndex];
            result.VapTurnout =
                double.Parse(StripOnSpaces(csvDataRow[VapTurnoutColumnIndex]), CultureInfo.InvariantCulture);
            result.VoterTurnout = double.Parse(StripOnSpaces(csvDataRow[VoterTurnoutColumnIndex]),
                CultureInfo.InvariantCulture);
            result.VotingAge =
                int.Parse(ReplaceCommasInThousands(csvDataRow[VotingAgeColumnIndex]), CultureInfo.InvariantCulture);
            result.Year = int.Parse(csvDataRow[YearColumnIndex], CultureInfo.InvariantCulture);

            return result;
        }

        private string StripOnSpaces(string input)
        {
            if (input.Equals(""))
                return "-1";

            var output = input.Substring(0, input.IndexOf(' '));
            return output;
        }

        private string ReplaceCommasInThousands(string input)
        {
            if (input.Equals(""))
                return "-1";

            var output = input.Replace(",", "");
            return output;
        }
    }
}