using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class InterestModelFactory : ICsvModelFactory<InterestModel>
    {
        private const int CountryColumnIndex = 0;
        private const int YearColumnIndex = 5;
        private const int ValueColumnIndex = 6;

        public InterestModel Create(List<string> csvDataRow)
        {
            var countryName = csvDataRow[CountryColumnIndex];
            var year = int.Parse(StripOnUnderScore(csvDataRow[YearColumnIndex]), CultureInfo.InvariantCulture);
            var value = double.Parse(csvDataRow[ValueColumnIndex], CultureInfo.InvariantCulture);
            return new InterestModel
            {
                CountryName = countryName,
                Year = year,
                Value = value
            };
        }

        private static string StripOnUnderScore(string word)
        {
            var indexOfScore = word.IndexOf('-');
            return indexOfScore > -1 ? word.Substring(0, indexOfScore) : word;
        }
    }
}