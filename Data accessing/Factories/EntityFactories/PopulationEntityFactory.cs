using System;
using System.Collections.Generic;
using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class PopulationEntityFactory : EntityFactory<PopulationModel, PopulationEntity>
    {
        public override PopulationEntity Create(PopulationModel rawModel)
        {
            //this one is not used.
            throw new NotImplementedException();
        }

        public IEnumerable<PopulationEntity> Convert(PopulationModel rawModel)
        {
            var results = rawModel.ValueByYear.Select(valueByYear => new PopulationEntity
            {
                CountryCode = CreateCountryCode(
                    rawModel.CountryName.IndexOf(' ') > 0
                        ? rawModel.CountryName.Substring(0, rawModel.CountryName.IndexOf(' '))
                        : rawModel.CountryName
                ),
                Year = valueByYear.Key,
                Value = (int) (valueByYear.Value * 1000)
            });

            return results;
        }
    }
}