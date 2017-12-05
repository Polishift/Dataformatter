using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Misc;

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
                Year = int.Parse(HelperFunctions.ReplaceCommasInThousands(csvDataRow[YearColumnIndex])),
                ChrstProt = int.Parse(HelperFunctions.ReplaceCommasInThousands(csvDataRow[ChrstProtColumnIndex])),
                ChrstCat = int.Parse(HelperFunctions.ReplaceCommasInThousands(csvDataRow[ChrstCatColumnIndex])),
                ChrstTotal = int.Parse(HelperFunctions.ReplaceCommasInThousands(csvDataRow[ChrstTotalColumnIndex])),

                JudTotal = int.Parse(HelperFunctions.ReplaceCommasInThousands(csvDataRow[JudTotalColumnIndex])),

                IslmTotal = int.Parse(HelperFunctions.ReplaceCommasInThousands(csvDataRow[IslmTotalColumnIndex])),

                BudTotal = int.Parse(HelperFunctions.ReplaceCommasInThousands(csvDataRow[BudTotalColumnIndex])),

                NonTotal = int.Parse(HelperFunctions.ReplaceCommasInThousands(csvDataRow[NonTotalColumnIndex])),

                SumTotal = int.Parse(HelperFunctions.ReplaceCommasInThousands(csvDataRow[SumTotalColumnIndex]))
            };
        }
    }
}