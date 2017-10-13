using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class ReligionModelFactory : ICsvModelFactory<ReligionModel>
    {
        private const int CountryNameColumnIndex = 5;

        private const int YearColumnIndex = 2;

        // Christianity
        private const int ChrstProtColumnIndex = 8;
        private const int ChrstCatColumnIndex = 9;
        private const int ChrstOrthColumnIndex = 10;
        private const int ChrstAngColumnIndex = 11;
        private const int ChrstOtherColumnIndex = 12;
        private const int ChrstTotalColumnIndex = 13;

        // Judaism
        private const int JudOrthColumnIndex = 14;
        private const int JudConsColumnIndex = 15;
        private const int JudRefColumnIndex = 16;
        private const int JudOtherColumnIndex = 17;
        private const int JudTotalColumnIndex = 18;

        // Islam
        private const int IslmSunColumnIndex = 19;
        private const int IslmShiColumnIndex = 20;
        private const int IslmIbdColumnIndex = 21;
        private const int IslmNatColumnIndex = 22;
        private const int IslmAlwColumnIndex = 23;
        private const int IslmAhmColumnIndex = 24;
        private const int IslmOtherColumnIndex = 25;
        private const int IslmTotalColumnIndex = 26;

        // Budism
        private const int BudMahColumnIndex = 27;
        private const int BudThrColumnIndex = 28;
        private const int BudOtherColumnIndex = 29;
        private const int BudTotalColumnIndex = 30;

        // Zoroastrian
        private const int ZoroTotalColumnIndex = 31;

        // Hindu
        private const int HindTotalColumnIndex = 32;

        // Sikh
        private const int SikhTotalColumnIndex = 33;

        // Shinto
        private const int ShntTotalColumnIndex = 34;

        // Baha'i
        private const int BahTotalColumnIndex = 35;

        // Taoism
        private const int TaoTotalColumnIndex = 36;

        // Confucianism
        private const int ConfTotalColumnIndex = 37;

        // Jainism
        private const int JainTotalColumnIndex = 38;

        // Syncretic Religions
        private const int SyncTotalColumnIndex = 39;

        // Animist Religions
        private const int AnmTotalColumnIndex = 40;

        // Non. religious
        private const int NonTotalColumnIndex = 41;

        // Other Religions
        private const int OtherTotalColumnIndex = 42;

        // Total 
        private const int SumTotalColumnIndex = 43;


        public ReligionModel Create(List<string> csvDataRow)
        {
            return new ReligionModel
            {
                CountryName = csvDataRow[CountryNameColumnIndex],
                Year = int.Parse(csvDataRow[YearColumnIndex]),

                ChrstProt = int.Parse(csvDataRow[ChrstProtColumnIndex]),
                ChrstCat = int.Parse(csvDataRow[ChrstCatColumnIndex]),
                ChrstOrth = int.Parse(csvDataRow[ChrstOrthColumnIndex]),
                ChrstAng = int.Parse(csvDataRow[ChrstAngColumnIndex]),
                ChrstOther = int.Parse(csvDataRow[ChrstOtherColumnIndex]),
                ChrstTotal = int.Parse(csvDataRow[ChrstTotalColumnIndex]),

                JudOrth = int.Parse(csvDataRow[JudOrthColumnIndex]),
                JudCons = int.Parse(csvDataRow[JudConsColumnIndex]),
                JudRef = int.Parse(csvDataRow[JudRefColumnIndex]),
                JudOther = int.Parse(csvDataRow[JudOtherColumnIndex]),
                JudTotal = int.Parse(csvDataRow[JudTotalColumnIndex]),

                IslmSun = int.Parse(csvDataRow[IslmSunColumnIndex]),
                IslmShi = int.Parse(csvDataRow[IslmShiColumnIndex]),
                IslmIbd = int.Parse(csvDataRow[IslmIbdColumnIndex]),
                IslmNat = int.Parse(csvDataRow[IslmNatColumnIndex]),
                IslmAlw = int.Parse(csvDataRow[IslmAlwColumnIndex]),
                IslmAhm = int.Parse(csvDataRow[IslmAhmColumnIndex]),
                IslmOther = int.Parse(csvDataRow[IslmOtherColumnIndex]),
                IslmTotal = int.Parse(csvDataRow[IslmTotalColumnIndex]),

                BudMah = int.Parse(csvDataRow[BudMahColumnIndex]),
                BudThr = int.Parse(csvDataRow[BudThrColumnIndex]),
                BudOther = int.Parse(csvDataRow[BudOtherColumnIndex]),
                BudTotal = int.Parse(csvDataRow[BudTotalColumnIndex]),

                ZoroTotal = int.Parse(csvDataRow[ZoroTotalColumnIndex]),
                HindTotal = int.Parse(csvDataRow[HindTotalColumnIndex]),
                SikhTotal = int.Parse(csvDataRow[SikhTotalColumnIndex]),
                ShntTotal = int.Parse(csvDataRow[ShntTotalColumnIndex]),
                BahTotal = int.Parse(csvDataRow[BahTotalColumnIndex]),
                TaoTotal = int.Parse(csvDataRow[TaoTotalColumnIndex]),
                ConfTotal = int.Parse(csvDataRow[ConfTotalColumnIndex]),
                JainTotal = int.Parse(csvDataRow[JainTotalColumnIndex]),
                SyncTotal = int.Parse(csvDataRow[SyncTotalColumnIndex]),
                AnmTotal = int.Parse(csvDataRow[AnmTotalColumnIndex]),
                
                NonTotal = int.Parse(csvDataRow[NonTotalColumnIndex]),
                OtherTotal = int.Parse(csvDataRow[OtherTotalColumnIndex]),
                SumTotal = int.Parse(csvDataRow[SumTotalColumnIndex])
            };

        }
    }
}