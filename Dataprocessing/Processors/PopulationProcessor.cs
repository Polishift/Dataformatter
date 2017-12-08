using System.Collections.Generic;
using System.IO;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories;
using Dataformatter.Data_accessing.Factories.EntityFactories;
// using Newtonsoft.Json;

namespace Dataformatter.Dataprocessing.Processors
{
    public class PopProcessor : AbstractDataProcessor<PopModel, PopEntity>
    {
        public override void SerializeDataToJson(List<PopModel> rawModels)
        {
            var PopEntities = new List<PopEntity>();
            var entityFactory = new DefaultPopEntityFactory();

            for (var i = 0; i < rawModels.Count; i++)
            {
                PopEntities.Add(entityFactory.Create(rawModels[i]));
            }

            WriteEntitiesToJson(EntityNames.Pop, PopEntities);
        }
    }
}