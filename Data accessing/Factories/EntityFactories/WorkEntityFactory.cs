using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class WorkEntityFactory : EntityFactory<WorkModel, WorkEntity>
    {
        public override WorkEntity Create(WorkModel rawModel)
        {
            return new WorkEntity
            {
                CountryCode = CreateCountryCode(rawModel.CountryName),
                Year = rawModel.Year,
                MilitairPop = (int) (rawModel.MilitairPop * 1000),
                UrbanPop = (int) (rawModel.UrbanPop * 1000)
            };
        }
    }
}