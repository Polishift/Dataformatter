using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories.EntityFactories;

namespace Dataformatter.Dataprocessing.Processors
{
    public class CountryInformationProcessor : AbstractDataProcessor<CountryInformationModel,
        CountryInformationEntity>
    {
        private readonly CountryInformationEntityFactory _defaultCountryEntityFactory =
            new CountryInformationEntityFactory();

        public override void SerializeDataToJson(List<CountryInformationModel> rawModels)
        {
            var countryBordersEntities = new List<CountryInformationEntity>();

            for (var i = 0; i < rawModels.Count; i++)
            {
                var currentRawModel = rawModels[i];
                countryBordersEntities.Add(_defaultCountryEntityFactory.Create(currentRawModel));
            }
            WriteEntitiesToJson(EntityNames.CountryBorders, countryBordersEntities);
        }
    }
}