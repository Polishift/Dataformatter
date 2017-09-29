using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;


namespace Dataformatter.Dataprocessing.Processors
{
    public enum EntityNames
    {
        PartyClassification,
        Election,
        Turnout
    }

    public abstract class AbstractDataProcessor<I, O> where I : IModel
                                                      where O : IEntity
    {
        private const string DIRECTORY = "ProcessedData/";

        public abstract void SerializeDataToJson(List<I> rawModels);

        protected void WriteEntitiesToJson(EntityNames entityName, IReadOnlyList<O> entities)
        {
            var orderedByCoutry = SortByCountry(entities);
            foreach (var countryPair in orderedByCoutry)
            {
                //this checks if the directory exists. If we don't do this, it will throw an exception
                if (!System.IO.Directory.Exists(DIRECTORY))
                    System.IO.Directory.CreateDirectory(DIRECTORY);
                
                var resultFile = DIRECTORY + Enum.GetName(typeof(EntityNames), entityName) + "_" + countryPair.Key +
                                 ".json";

                if (!File.Exists(resultFile))
                    File.Create(resultFile).Dispose();

                using (var file = File.CreateText(resultFile))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(file, countryPair.Value);
                }
            }
        }

        private Dictionary<string, List<O>> SortByCountry(IReadOnlyList<O> allEntities)
        {
            var result = new Dictionary<string, List<O>>();
            for (var i = 0; i < allEntities.Count; i++)
            {
                var election = allEntities[i];

                if (!result.ContainsKey(election.CountryCode))
                    result.Add(election.CountryCode, new List<O>());

                result[election.CountryCode].Add(election);
            }
            return result;
        }
    }
}