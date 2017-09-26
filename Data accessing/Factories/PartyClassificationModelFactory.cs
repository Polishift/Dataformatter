using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories
{
    class PartyClassificationModelFactory : IModelFactory<PartyClassificationModel>
    {
        private const int CountryColumnIndex = 1;
        private const int ClassificationColumnIndex = 13;
        private const int PartynameColumnIndex = 4;

        public PartyClassificationModel Create(List<string> csvDataRow)
        {
            return new PartyClassificationModel
            {
                CountryName = csvDataRow[CountryColumnIndex],
                Classification = csvDataRow[ClassificationColumnIndex],
                Name = csvDataRow[PartynameColumnIndex]
            };
        }
    }
}