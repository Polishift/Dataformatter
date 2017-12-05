using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class TvEntityFactory : EntityFactory<TvModel,
        TvEntity>
    {
        public override TvEntity Create(TvModel rawModel)
        {
            return new TvEntity
            {
                CountryCode = CreateCountryCode(rawModel.CountryName),
                Year = rawModel.Year,
                Value = rawModel.Value
            };
        }
    }
}