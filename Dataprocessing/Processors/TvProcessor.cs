using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories.EntityFactories;

namespace Dataformatter.Dataprocessing.Processors
{
    public class TvProcessor : AbstractDataProcessor<TvModel, TvEntity>
    {
        public override void SerializeDataToJson(List<TvModel> rawModels)
        {
            var tvEntities = new List<TvEntity>();
            var entityFactory = new TvEntityFactory();

            for (var i = 0; i < rawModels.Count; i++)
            {
                tvEntities .Add(entityFactory.Create(rawModels[i]));
            }

            WriteEntitiesToJson(EntityNames.Tv, tvEntities);
        }
    }
}