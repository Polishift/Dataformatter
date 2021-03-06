using System;
using System.Collections.Generic;
using System.IO;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Newtonsoft.Json;

namespace Dataformatter.Dataprocessing.Processors
{
    public enum EntityNames
    {
        PartyClassification,
        Election,
        Turnout,
        CountryBorders,
        PartyFamilies,
        Employment,
        Religion,
        Interest,
        War,
        Tv,
        Population,
        GdpTotal,
        GdpPerCapita,
        Work,
        TotalCountryInformationEntities
    }

    public abstract class AbstractDataProcessor<I, O> where I : IModel
        where O : IEntity
    {
        // ReSharper disable once StaticMemberInGenericType
        private static readonly string Directory = Paths.ProcessedDataFolder;

        public abstract void SerializeDataToJson(List<I> rawModels);

        protected void WriteEntitiesToJson(EntityNames entityName, IList<O> entities)
        {
            var orderedByCoutry = SortByCountry(entities);
            foreach (var countryPair in orderedByCoutry)
            {
                CreateDirectoryIfNotExists();
                var resultFileName = CreateCurrentCountryFileName(entityName, countryPair.Key);

                SerializeFile(resultFileName, countryPair.Value);
            }
        }

        private static Dictionary<string, List<O>> SortByCountry(IList<O> allEntities)
        {
            var result = new Dictionary<string, List<O>>();
            for (var i = 0; i < allEntities.Count; i++)
            {
                var entity = allEntities[i];

                if (!result.ContainsKey(entity.CountryCode))
                    result.Add(entity.CountryCode, new List<O>());

                result[entity.CountryCode].Add(entity);
            }
            return result;
        }


        private static void CreateDirectoryIfNotExists()
        {
            if (!System.IO.Directory.Exists(Directory))
                System.IO.Directory.CreateDirectory(Directory);
        }

        private static string CreateCurrentCountryFileName(EntityNames entityName, string countryName)
        {
            return Directory + Enum.GetName(typeof(EntityNames), entityName) + "_" + countryName
                   + ".json";
        }

        private static void SerializeFile(string fileName, List<O> entityList)
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