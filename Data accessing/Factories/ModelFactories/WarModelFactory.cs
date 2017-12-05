using System;
using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class WarModelFactory : ICsvModelFactory<WarModel>
    {
        private const int NameColumnIndex = 1;
        private const int CountryColumnIndex = 2;
        private const int ActorsColumnIndex = 3;
        private const int StartYearColumnIndex = 6;
        private const int EndYearColumnIndex = 9;

        public WarModel Create(List<string> csvDataRow)
        {
            var indexOfCountryName = csvDataRow[NameColumnIndex].IndexOf("-", StringComparison.InvariantCulture);
            var countryName = indexOfCountryName < 0
                ? "unknown"
                : csvDataRow[NameColumnIndex].Substring(0, indexOfCountryName);
            var name = csvDataRow[NameColumnIndex];
            var startyear = int.Parse(csvDataRow[StartYearColumnIndex], CultureInfo.InvariantCulture);
            var endyear = csvDataRow[EndYearColumnIndex].Equals("")
                ? 0
                : int.Parse(csvDataRow[EndYearColumnIndex], CultureInfo.InvariantCulture);
            var actors = csvDataRow[ActorsColumnIndex].Equals("")
                ? 0
                : int.Parse(csvDataRow[ActorsColumnIndex], CultureInfo.InvariantCulture);
            
            return new WarModel
            {
                Name = name,
                CountryName = countryName,
                StartYear = startyear,
                EndYear = endyear,
                Actors = actors
            };
        }
    }
}