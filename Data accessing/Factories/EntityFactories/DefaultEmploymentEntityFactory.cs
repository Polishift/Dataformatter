using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class DefaultEmploymentEntityFactory : EntityFactory<EmploymentModel,
                                                             EmploymentEntity>
    {
        public override EmploymentEntity Create(EmploymentModel rawModel)
        {
            return new EmploymentEntity
            {
                CountryCode = CreateCountryCode(rawModel.CountryName),
                Year = rawModel.Year,
                EmployedPercentage = rawModel.EmployedPercentage             
            };

            
        }

        
    }
}