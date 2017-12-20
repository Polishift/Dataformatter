using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories.EntityFactories;

namespace Dataformatter.Dataprocessing.Processors
{
    public class WorkProcessor : AbstractDataProcessor<WorkModel, WorkEntity>
    {
        public override void SerializeDataToJson(List<WorkModel> rawModels)
        {
            var workEntities = new List<WorkEntity>();
            var entityFactory = new WorkEntityFactory();

            for (var i = 0; i < rawModels.Count; i++)
            {
                workEntities.Add(entityFactory.Create(rawModels[i]));
            }

            WriteEntitiesToJson(EntityNames.Work, workEntities);
        }
    }
}