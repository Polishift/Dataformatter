using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories
{
    public class DefaultPartyClassificationEntityFactory
    {
        public PartyClassificationEntity Create(PartyClassificationModel rawModel)
        {
            return new PartyClassificationEntity
            {
                Name = rawModel.Name,
                CountryCode = CreateCountryCode(rawModel.CountryName),
                Classification = rawModel.Classification
            };
        }

        //todo add this to helper functions to make it more generic
        private static string CreateCountryCode(string fullCountryName)
        {
            return fullCountryName;
        }
    }
}