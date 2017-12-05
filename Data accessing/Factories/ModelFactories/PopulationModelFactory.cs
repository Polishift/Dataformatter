using System;
using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class PopulationModelFactory : ICsvModelFactory<PopulationModel>
    {
        private const int CountryColumnIndex = 0;
        private const int ValueColumnIndex = 135;

        public PopulationModel Create(List<string> csvDataRow)
        {
            //this one differs from the rest, since the csv is made up differently.
            //therefore a dictionary is made.
            var dictionary = new Dictionary<int, double>();
            for (var i = 0; i < 66; i++)
            {
                if (csvDataRow[ValueColumnIndex + i].Equals("")) continue;
                if (csvDataRow[ValueColumnIndex + i].Equals("n.a.")) continue;
                var year = 1944 + i;
                dictionary.Add(year, double.Parse(csvDataRow[ValueColumnIndex + i]));
            }

            var countryName = csvDataRow[CountryColumnIndex];

            return new PopulationModel
            {
                CountryName = countryName,
                ValueByYear = dictionary
            };
        }
    }
}