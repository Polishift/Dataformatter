using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories.EntityFactories;

namespace Dataformatter.Dataprocessing.Processors
{
    public class PopulationProcessor : AbstractDataProcessor<PopulationModel, PopulationEntity>
    {
        public override void SerializeDataToJson(List<PopulationModel> rawModels)
        {
            var populationEntities = new List<PopulationEntity>();
            var entityFactory = new PopulationEntityFactory();

            for (var i = 0; i < rawModels.Count; i++)
                populationEntities.AddRange(entityFactory.Convert(rawModels[i]));

            WriteEntitiesToJson(EntityNames.Population, populationEntities);
        }
    }
}