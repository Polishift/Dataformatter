using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class DefaultPopEntityFactory : EntityFactory<PopModel,
        PopEntity>
    {
        public override PopEntity Create(PopModel rawModel)
        {
            return new PopEntity
            {
                CountryCode = CreateCountryCode(rawModel.CountryName),
                Year = rawModel.Year,
                MilitairPop = rawModel.MilitairPop * 1000,
                UrbanPop = rawModel.UrbanPop * 1000,
                TotalPop = rawModel.TotalPop * 1000,
                NonUrbanPop = (rawModel.TotalPop - (rawModel.MilitairPop + rawModel.UrbanPop)) * 1000
            };
        }
    }
}