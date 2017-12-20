using System;
using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class WorkModelFactory : ICsvModelFactory<WorkModel>
    {
        private const int CountryNameColumnIndex = 0;

        private const int YearColumnIndex = 2;

        private const int MilitairPopColumnIndex = 4;

        private const int UrbanPopColumnIndex = 8;


        public WorkModel Create(List<string> csvDataRow)
        {
            var countryName = csvDataRow[CountryNameColumnIndex];
            var year = int.Parse(csvDataRow[YearColumnIndex]);
            var militairPop = double.Parse(csvDataRow[MilitairPopColumnIndex], CultureInfo.InvariantCulture);
            var urbanPop = double.Parse(csvDataRow[UrbanPopColumnIndex], CultureInfo.InvariantCulture);
            return new WorkModel
            {
                CountryName = countryName,
                Year = year,
                MilitairPop = militairPop,
                UrbanPop = urbanPop
            };
        }
    }
}