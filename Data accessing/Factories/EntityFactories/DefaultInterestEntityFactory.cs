using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class DefaultInterestEntityFactory : EntityFactory<InterestModel,
        InterestEntity>
    {
        public override InterestEntity Create(InterestModel rawModel)
        {
            return new InterestEntity
            {
                CountryCode = CreateCountryCode(rawModel.CountryName),
                Value = rawModel.Value,
                Year = rawModel.Year
            };
        }
    }
}