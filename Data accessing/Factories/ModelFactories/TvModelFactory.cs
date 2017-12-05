using System;
using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;
using Dataformatter.Misc;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class TvModelFactory : ICsvModelFactory<TvModel>
    {
        private const int ValueColumnIndex = 1;
        private const int CountryColumnIndex = 0;
        private const int YearColumnIndex = 2;

        public TvModel Create(List<string> csvDataRow)
        {
            var countryName = csvDataRow[CountryColumnIndex];
            var value = double.Parse(HelperFunctions.StripOnPercent(csvDataRow[ValueColumnIndex]), CultureInfo.InvariantCulture);
            var year = int.Parse(csvDataRow[YearColumnIndex], CultureInfo.InvariantCulture);

            return new TvModel
            {
                Value = value,
                CountryName = countryName,
                Year = year
            };
        }
    }
}