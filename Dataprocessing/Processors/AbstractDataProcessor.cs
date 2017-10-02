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
                CreateDirectoryIfNotExists();
                var resultFileName = CreateCurrentCountryFileName(entityName, countryPair.Key);

                SerializeFile(resultFileName, countryPair.Value);
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


        private void CreateDirectoryIfNotExists()
        {
            if (!System.IO.Directory.Exists(DIRECTORY))
                System.IO.Directory.CreateDirectory(DIRECTORY);
        }

        private string CreateCurrentCountryFileName(EntityNames entityName, string countryName)
        {
            return DIRECTORY + Enum.GetName(typeof(EntityNames), entityName) + "_" + countryName 
                             + ".json";
        }

        private void SerializeFile(string fileName, List<O> entityList)
        {
            if (!File.Exists(fileName))
                File.Create(fileName).Dispose();

            using (var file = File.CreateText(fileName))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, entityList);
            }
        }
    }
}