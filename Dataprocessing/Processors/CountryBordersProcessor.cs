using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories;
using Dataformatter.Data_accessing.Factories.EntityFactories;
using Newtonsoft.Json;

namespace Dataformatter.Dataprocessing.Processors
{
    class CountryBordersProcessor : AbstractDataProcessor<CountryGeoModel,  
                                                          CountryBordersEntity>
    {
        private DefaultCountryBordersEntityFactory defaultCountryBordersEntityFactory = new DefaultCountryBordersEntityFactory();

        public override void SerializeDataToJson(List<CountryGeoModel> rawModels)
        {
            var countryBordersEntities = new List<CountryBordersEntity>();

            for(var i = 0; i < rawModels.Count; i++)
            {
                var currentRawModel = rawModels[i];
                countryBordersEntities.Add(defaultCountryBordersEntityFactory.Create(currentRawModel));
            }
            WriteEntitiesToJson(EntityNames.CountryBorders, countryBordersEntities);
        }
    }
}