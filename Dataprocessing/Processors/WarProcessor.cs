using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories.EntityFactories;

namespace Dataformatter.Dataprocessing.Processors
{
    public class WarProcessor : AbstractDataProcessor<WarModel, WarEntity>
    {
        public override void SerializeDataToJson(List<WarModel> rawModels)
        {
            var warEntities = new List<WarEntity>();
            var entityFactory = new WarEntityFactory();

            for (var i = 0; i < rawModels.Count; i++)
                if (rawModels[i].EndYear > 1945)
                    warEntities.Add(entityFactory.Create(rawModels[i]));

            WriteEntitiesToJson(EntityNames.War, warEntities);
        }
    }
}