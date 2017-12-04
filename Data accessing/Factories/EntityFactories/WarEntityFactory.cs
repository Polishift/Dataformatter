using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class WarEntityFactory : EntityFactory<WarModel,
        WarEntity>
    {
        public override WarEntity Create(WarModel rawModel)
        {
            return new WarEntity
            {
                CountryCode = CreateCountryCode(rawModel.CountryName),
                Name = rawModel.Name,
                StartYear = rawModel.StartYear,
                EndYear = rawModel.EndYear,
                Actors = rawModel.Actors
            };
        }
    }
}