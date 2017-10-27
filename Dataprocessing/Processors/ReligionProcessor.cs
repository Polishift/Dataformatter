using System.Collections.Generic;
using System.IO;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories;
using Dataformatter.Data_accessing.Factories.EntityFactories;
using Newtonsoft.Json;

namespace Dataformatter.Dataprocessing.Processors
{
    public class ReligionProcessor : AbstractDataProcessor<ReligionModel, ReligionEntity>
    {
        public override void SerializeDataToJson(List<ReligionModel> rawModels)
        {
            var ReligionEntities = new List<ReligionEntity>();
            var entityFactory = new DefaultReligionEntityFactory();
            
            for (var i = 0; i < rawModels.Count; i++)
            {
                ReligionEntities.Add(entityFactory.Create(rawModels[i]));
            }

            WriteEntitiesToJson(EntityNames.Religion, ReligionEntities);   
        }
    }
}