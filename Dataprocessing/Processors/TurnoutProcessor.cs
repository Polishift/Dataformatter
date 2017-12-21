using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories.EntityFactories;

namespace Dataformatter.Dataprocessing.Processors
{
    public class TurnoutProcessor : AbstractDataProcessor<TurnoutModel, TurnoutEntity>
    {
        public override void SerializeDataToJson(List<TurnoutModel> rawModels)
        {
            var turnoutEntities = new List<TurnoutEntity>();
            var entityFactory = new TurnoutEntityFactory();

            for (var i = 0; i < rawModels.Count; i++)
                turnoutEntities.Add(entityFactory.Create(rawModels[i]));

            WriteEntitiesToJson(EntityNames.Turnout, turnoutEntities);
        }
    }
}