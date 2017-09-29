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
    class PartyClassificationProcessor : AbstractDataProcessor<PartyClassificationModel, 
                                                               PartyClassificationEntity>
    {
        public override void SerializeDataToJson(List<PartyClassificationModel> rawModels)
        {
            var entityFactory = new DefaultPartyClassificationEntityFactory();
            var classificationPerParty = new Dictionary<int, PartyClassificationEntity>();

            for (var i = 0; i < rawModels.Count; i++)
            {
                var model = rawModels[i];
                if (classificationPerParty.ContainsKey(model.Id))
                    continue;

                classificationPerParty.Add(model.Id, entityFactory.Create(model));
            }
            WriteEntitiesToJson(EntityNames.PartyClassification, classificationPerParty.Values.ToList());
        }
    }
}