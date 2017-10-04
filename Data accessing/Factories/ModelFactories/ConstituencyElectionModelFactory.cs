using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    class ConstituencyElectionModelFactory : ICsvModelFactory<ConstituencyElectionModel>
    {
        //Missingcodes
        private readonly HashSet<string> INVALID_VALUE_CODES = new HashSet<string>(){ "-990", "-992", "-994"};

        //Indexes
        private const int YEAR_COLUMN_INDEX = 4;
        private const int COUNTRY_COLUMN_INDEX = 2;
        private const int CONSTITUENCY_COLUMN_INDEX = 7;

        private const int PARTYNAME_COLUMN_INDEX = 10;
        private const int CANDIDATE_COLUMN_INDEX = 12;

        private const int TOTALVOTESAMOUNT_COLUMN_INDEX = 15;
        private const int PARTYVOTESAMOUNT_COLUMN_INDEX = 20;
        
        private const int SECOND_ROUND_PARTYVOTESAMOUNT_COLUMN_INDEX = 29;
        private const int SEATSGAINED_COLUMN_INDEX = 31;

        public ConstituencyElectionModel Create(List<string> csvDataRow)
        {
            var filteredCsvDataRow = FilterInvalidValues(csvDataRow);

            return new ConstituencyElectionModel
            {
                CountryName = filteredCsvDataRow[COUNTRY_COLUMN_INDEX],
                ConstituencyName = filteredCsvDataRow[CONSTITUENCY_COLUMN_INDEX],
                Year = int.Parse(filteredCsvDataRow[YEAR_COLUMN_INDEX]),
                PartyName = filteredCsvDataRow[PARTYNAME_COLUMN_INDEX],
                CandidateName = filteredCsvDataRow[CANDIDATE_COLUMN_INDEX],
                TotalAmountOfVotes = int.Parse(filteredCsvDataRow[TOTALVOTESAMOUNT_COLUMN_INDEX], CultureInfo.InvariantCulture),
                AmountOfPartyVotes = double.Parse(filteredCsvDataRow[PARTYVOTESAMOUNT_COLUMN_INDEX], CultureInfo.InvariantCulture),
                SecondRoundAmountOfPartyVotes = int.Parse(filteredCsvDataRow[SECOND_ROUND_PARTYVOTESAMOUNT_COLUMN_INDEX],
                    CultureInfo.InvariantCulture),
                SeatsGained = int.Parse(filteredCsvDataRow[SEATSGAINED_COLUMN_INDEX])
            };
        }

        private List<string> FilterInvalidValues(List<string> csvDataRow)
        {
            var filteredDataRow = csvDataRow;

            for(int i = 0; i < csvDataRow.Count; i++)
            {
                if(i == CANDIDATE_COLUMN_INDEX && IsInvalidValue(csvDataRow[i])) 
                {
                    filteredDataRow[i] = "Unknown";
                }
                 //Anything but candidate names that can also be invalid is represented as a number, hence 0 instead of "Unknown"
                else if(IsInvalidValue(csvDataRow[i]))
                {
                    filteredDataRow[i] = "0";
                }
            }
            return filteredDataRow;
        }

        private bool IsInvalidValue(string value)
        {
            return INVALID_VALUE_CODES.Contains(value);
        }
    }
}