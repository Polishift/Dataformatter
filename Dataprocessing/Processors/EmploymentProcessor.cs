using System.Collections.Generic;
using System.IO;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories;
using Dataformatter.Data_accessing.Factories.EntityFactories;
using Newtonsoft.Json;

namespace Dataformatter.Dataprocessing.Processors
{
    public class EmploymentProcessor : AbstractDataProcessor<EmploymentModel, EmploymentEntity>
    {
        public override void SerializeDataToJson(List<EmploymentModel> rawModels)
        {
            var EmploymentEntities = new List<EmploymentEntity>();
            var entityFactory = new DefaultEmploymentEntityFactory();
            
            for (var i = 0; i < rawModels.Count; i++)
            {
                EmploymentEntities.Add(entityFactory.Create(rawModels[i]));
            }

            WriteEntitiesToJson(EntityNames.Employment, EmploymentEntities);   
        }
    }
}