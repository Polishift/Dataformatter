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
            var employmentEntities = new List<EmploymentEntity>();
            var entityFactory = new EmploymentEntityFactory();

            for (var i = 0; i < rawModels.Count; i++)
            {
                employmentEntities.Add(entityFactory.Create(rawModels[i]));
            }

            WriteEntitiesToJson(EntityNames.Employment, employmentEntities);
        }
    }
}