using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    class ConstituencyElectionModelFactory : IModelFactory<ConstituencyElectionModel>
    {
        private const int COUNTRY_COLUMN_INDEX = 2;
        private const int YEAR_COLUMN_INDEX = 4;

        private const int PARTYNAME_COLUMN_INDEX = 10;
        private const int CANDIDATE_COLUMN_INDEX = 12;

        private const int VOTEFRACTION_COLUMN_INDEX = 21;
        private const int SECOND_ROUND_VOTEFRACTION_COLUMN_INDEX = 30;
        private const int SEATSGAINED_COLUMN_INDEX = 31;

        public ConstituencyElectionModel Create(List<string> csvDataRow)
        {
            return new ConstituencyElectionModel
            {
                CountryName = csvDataRow[COUNTRY_COLUMN_INDEX],
                Year = int.Parse(csvDataRow[YEAR_COLUMN_INDEX]),
                PartyName = csvDataRow[PARTYNAME_COLUMN_INDEX],
                CandidateName = csvDataRow[CANDIDATE_COLUMN_INDEX],
                VoteFraction = double.Parse(csvDataRow[VOTEFRACTION_COLUMN_INDEX], CultureInfo.InvariantCulture),
                SecondRoundVoteFraction = double.Parse(csvDataRow[SECOND_ROUND_VOTEFRACTION_COLUMN_INDEX],
                    CultureInfo.InvariantCulture),
                SeatsGained = int.Parse(csvDataRow[SEATSGAINED_COLUMN_INDEX])
            };
        }
    }
}