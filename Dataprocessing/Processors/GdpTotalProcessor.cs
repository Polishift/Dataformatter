using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories.EntityFactories;

namespace Dataformatter.Dataprocessing.Processors
{
    public class GdpTotalProcessor : AbstractDataProcessor<GdpTotalModel, GdpTotalEntity>
    {
        public override void SerializeDataToJson(List<GdpTotalModel> rawModels)
        {
            var gdpEntities = new List<GdpTotalEntity>();
            var entityFactory = new GdpTotalEntityFactory();

            for (var i = 0; i < rawModels.Count; i++)
                gdpEntities.AddRange(entityFactory.Convert(rawModels[i]));

            WriteEntitiesToJson(EntityNames.GdpTotal, gdpEntities);
        }
    }
}