using System;
using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class PopulationModelFactory : ICsvModelFactory<PopulationModel>
    {
        private const int CountryColumnIndex = 0;
        private const int YearColumnIndex = 6;
        private const int ValueColumnIndex = 135;

        public PopulationModel Create(List<string> csvDataRow)
        {
            //this one differs from the rest, since the csv is made up differently.

            var dictionary = new Dictionary<int, double>();
            for (var i = 0; i < 66; i++)
            {
                if (csvDataRow[ValueColumnIndex + i].Equals("")) continue;
                var year = 1944 + i;
                if (csvDataRow[ValueColumnIndex + i].Equals("n.a.")) continue;
                dictionary.Add(year, double.Parse(csvDataRow[ValueColumnIndex + i]));
            }

            //this line is needed to strip the space.
            var countryName = csvDataRow[CountryColumnIndex];

            return new PopulationModel
            {
                CountryName = countryName,
                ValueByYear = dictionary
            };
        }
    }
}