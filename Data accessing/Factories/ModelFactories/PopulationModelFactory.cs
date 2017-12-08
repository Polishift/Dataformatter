using System;
using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class PopFactory : ICsvModelFactory<PopModel>
    {
        private const int CountryNameColumnIndex = 0;

        private const int YearColumnIndex = 2;

        private const int MilitairPopColumnIndex = 4;

        private const int UrbanPopColumnIndex = 8;


        public PopModel Create(List<string> csvDataRow)
        {
            return new PopModel
            {
                CountryName = csvDataRow[CountryNameColumnIndex],
                Year = int.Parse(csvDataRow[YearColumnIndex]),
                MilitairPop = int.Parse(csvDataRow[MilitairPopColumnIndex]),
                UrbanPop = int.Parse(csvDataRow[UrbanPopColumnIndex])
            };
        }
    }
}