using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories.EntityFactories;

namespace Dataformatter.Dataprocessing.Processors
{
    public class CountryBordersProcessor : AbstractDataProcessor<CountryGeoModel,
        CountryBordersEntity>
    {
        private readonly CountryEntityFactory _defaultCountryEntityFactory = new CountryEntityFactory();

        public override void SerializeDataToJson(List<CountryGeoModel> rawModels)
        {
            var countryBordersEntities = new List<CountryBordersEntity>();

            for (var i = 0; i < rawModels.Count; i++)
            {
                var currentRawModel = rawModels[i];
                countryBordersEntities.Add(_defaultCountryEntityFactory.Create(currentRawModel));
            }
            WriteEntitiesToJson(EntityNames.CountryBorders, countryBordersEntities);
        }
    }
}