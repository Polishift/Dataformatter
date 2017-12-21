using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories.EntityFactories;

namespace Dataformatter.Dataprocessing.Processors
{
    public class GdpPerCapitaProcessor : AbstractDataProcessor<GdpPerCapitaModel, GdpPerCapitaEntity>
    {
        public override void SerializeDataToJson(List<GdpPerCapitaModel> rawModels)
        {
            var gdpEntities = new List<GdpPerCapitaEntity>();
            var entityFactory = new GdpPerCapitaEntityFactory();

            for (var i = 0; i < rawModels.Count; i++)
                gdpEntities.AddRange(entityFactory.Convert(rawModels[i]));

            WriteEntitiesToJson(EntityNames.GdpPerCapita, gdpEntities);
        }
    }
}