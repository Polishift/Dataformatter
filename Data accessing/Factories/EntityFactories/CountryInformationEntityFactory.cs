using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class CountryInformationEntityFactory : EntityFactory<CountryInformationModel,
        CountryInformationEntity>
    {
        public override CountryInformationEntity Create(CountryInformationModel rawModel)
        {
            return new CountryInformationEntity
            {
                CountryCode = CreateCountryCode(rawModel.CountryName),
                Year = rawModel.Year
            };
        }
    }
}