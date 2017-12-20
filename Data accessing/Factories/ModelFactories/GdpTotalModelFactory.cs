using System;
using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class GdpTotalModelFactory : ICsvModelFactory<GdpTotalModel>
    {
        private const int CountryColumnIndex = 0;
        private const int ValueColumnIndex = 135;

        public GdpTotalModel Create(List<string> csvDataRow)
        {
            //this one differs from the rest, since the csv is made up differently.
            //therefore a dictionary is made.
            var dictionary = new Dictionary<int, double>();
            for (var i = 0; i < 63; i++)
            {
                if (csvDataRow[ValueColumnIndex + i].Equals("")) continue;
                if (csvDataRow[ValueColumnIndex + i].Equals("n.a.")) continue;
                var year = 1944 + i;
                dictionary.Add(year, double.Parse(csvDataRow[ValueColumnIndex + i]));
            }

            var countryName = csvDataRow[CountryColumnIndex];

            return new GdpTotalModel
            {
                CountryName = countryName,
                ValueByYear = dictionary
            };
        }
    }
}