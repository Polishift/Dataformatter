using System;
using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class ReligionModelFactory : ICsvModelFactory<ReligionModel>
    {
        private const int CountryNameColumnIndex = 4;

        private const int YearColumnIndex = 1;

        // Christianity
        private const int ChrstProtColumnIndex = 7;
        private const int ChrstCatColumnIndex = 8;
        private const int ChrstTotalColumnIndex = 12;

        // Judaism
        private const int JudTotalColumnIndex = 17;

        // Islam
        private const int IslmTotalColumnIndex = 25;

        // Budism
        private const int BudTotalColumnIndex = 29;

        // Non. religious
        private const int NonTotalColumnIndex = 40;

        // Other Religions
        private const int OtherTotalColumnIndex = 41;

        // Total 
        private const int SumTotalColumnIndex = 42;


        public ReligionModel Create(List<string> csvDataRow)
        {
            return new ReligionModel
            {
                CountryName = csvDataRow[CountryNameColumnIndex],
                Year = int.Parse(ReplaceCommasInThousands(csvDataRow[YearColumnIndex])),
                ChrstProt = int.Parse(ReplaceCommasInThousands(csvDataRow[ChrstProtColumnIndex])),
                ChrstCat = int.Parse(ReplaceCommasInThousands(csvDataRow[ChrstCatColumnIndex])),
                ChrstTotal = int.Parse(ReplaceCommasInThousands(csvDataRow[ChrstTotalColumnIndex])),

                JudTotal = int.Parse(ReplaceCommasInThousands(csvDataRow[JudTotalColumnIndex])),

                IslmTotal = int.Parse(ReplaceCommasInThousands(csvDataRow[IslmTotalColumnIndex])),

                BudTotal = int.Parse(ReplaceCommasInThousands(csvDataRow[BudTotalColumnIndex])),
                
                NonTotal = int.Parse(ReplaceCommasInThousands(csvDataRow[NonTotalColumnIndex])),

                SumTotal = int.Parse(ReplaceCommasInThousands(csvDataRow[SumTotalColumnIndex]))
            };

        }

        private string ReplaceCommasInThousands(string input)
        {
            if (input.Equals(""))
                return "-1";

            var output = input.Replace(",", "");
            return output;
        }
    }
}