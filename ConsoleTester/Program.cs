using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dataformatter;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Processors;
using Dataformatter.Data_accessing.Repositories;
using Newtonsoft.Json;

namespace ConsoleTester
{
    internal class Program
    {
        private static void Main()
        {
            Paths.SetProcessedDataFolder(@"C:\Users\ceesj\Documents\hogeschool\minor\Code\ProcessedData\");
            Paths.SetRawDataFolder(@"C:\Users\ceesj\Documents\hogeschool\minor\Code\Datasources\");
            
        // ReSharper disable once StaticMemberInGenericType


//            Paths.SetProcessedDataFolder(@"E:\Hogeschool\Polishift Organization\ProcessedData\");
//            Paths.SetRawDataFolder(@"E:\Hogeschool\Polishift Organization\Datasources\");

            #region ParseCode

/*

            var electionsCsvLocation = Paths.RawDataFolder + @"\Political\ElectionResults\election_data.csv";
            var interestCsvLocation = Paths.RawDataFolder +
                                      @"\Economical & Social\Interest rates (incomplete)\interest_data.csv";
            var warCsvLocation = Paths.RawDataFolder + @"\Economical & Social\Wars\war_data.csv";
            var tvCsvLocation = Paths.RawDataFolder +
                                @"\Economical & Social\Households with TV\households_with_television_data.csv";
            var populationCsvLocation = Paths.RawDataFolder +
                                        @"\Economical & Social\GDP & Population & GDP Per capita\population_data.csv";
            var gdpTotalCsvLocation = Paths.RawDataFolder +
                                      @"\Economical & Social\GDP & Population & GDP Per capita\gdp_data.csv";
            var gdpCapitaCsvLocation = Paths.RawDataFolder +
                                       @"\Economical & Social\GDP & Population & GDP Per capita\percapita_gdp_data.csv";
            var partyClassificationCsvLocation =
                Paths.RawDataFolder + @"/Political/PartyClassification\classificationData.csv";
            var turnoutCsvLocation = Paths.RawDataFolder + @"\Political\Turnout\turnout_data.csv";
            var workCsvLocation = Paths.RawDataFolder + @"\Economical & Social\NMC_5_0.csv";

            ICsvModelFactory<PopulationModel> modelFactory =
                new PopulationModelFactory();
            var allItemsAsModels = CsvToModel<PopulationModel>.ParseAllCsvLinesToModels(
                populationCsvLocation, modelFactory);
            var processor = new PopulationProcessor();
            processor.SerializeDataToJson(allItemsAsModels);
*/

            #endregion

            #region Parsing country borders

//            var countryBorderDirectory = Paths.ProcessedDataFolder+ @"countryInformation";
//            IJsonModelFactory<CountryGeoModel> countryGeoModelFactory = new CountryGeoModelFactory();
//            var processor2 = new CountryBordersProcessor();
//
//            var allCountryGeoModels =
//                JsonToModel<CountryGeoModel>.ParseJsonDirectoryToModels(countryBorderDirectory, countryGeoModelFactory,
//                    "*.geo.json");
//            processor2.SerializeDataToJson(allCountryGeoModels);
//
//            var countryBordersRepo = new CountryBordersRepository();
//            foreach (var country in countryBordersRepo.GetAll())
//            {
//                Console.WriteLine("Countrycode: " + country.CountryCode);    
//            }

            #endregion

            #region Filtering

            /*   IFilter filter = new YearFilter();
               filter.Filter();
   
               filter = new EuropeFilter();
               filter.Filter();*/

            #endregion

            /* var partyClassificationAndElectionsMerger = new PartyClassificationAndElectionsMerger();
             partyClassificationAndElectionsMerger.MergeIndividualCountry();*/

            var allCountryInfo = new Dictionary<string, Dictionary<int, CountryInformationEntity>>();
            IRepository<IEntity> repository = new EmploymentRepository();
            Console.WriteLine("Doing employment");

            foreach (var entity in repository.GetAll())
            {
                var employmentEntity = (EmploymentEntity) entity;
                if (!allCountryInfo.ContainsKey(employmentEntity.CountryCode))
                    allCountryInfo.Add(employmentEntity.CountryCode, new Dictionary<int, CountryInformationEntity>());
                if (!allCountryInfo[employmentEntity.CountryCode].ContainsKey(employmentEntity.Year))
                    allCountryInfo[employmentEntity.CountryCode]
                        .Add(employmentEntity.Year, new CountryInformationEntity {Year = employmentEntity.Year});
                allCountryInfo[employmentEntity.CountryCode][employmentEntity.Year].EmployedPercentage =
                    employmentEntity.EmployedPercentage;
            }
            Console.WriteLine("Doing gdptotal");
            repository = new GdpTotalRepository();
            foreach (var entity in repository.GetAll())
            {
                var gdpTotalEntity = (GdpTotalEntity) entity;
                if (!allCountryInfo.ContainsKey(gdpTotalEntity.CountryCode))
                    allCountryInfo.Add(gdpTotalEntity.CountryCode, new Dictionary<int, CountryInformationEntity>());
                if (!allCountryInfo[gdpTotalEntity.CountryCode].ContainsKey(gdpTotalEntity.Year))
                    allCountryInfo[gdpTotalEntity.CountryCode]
                        .Add(gdpTotalEntity.Year, new CountryInformationEntity {Year = gdpTotalEntity.Year});
                allCountryInfo[gdpTotalEntity.CountryCode][gdpTotalEntity.Year].GdpTotal =
                    gdpTotalEntity.Total;
            }
            
            repository = new GdpPerCapitaRepository();
            Console.WriteLine("Doing gdpcapita");

            foreach (var entity in repository.GetAll())
            {
                var gdpPerCapitaEntity = (GdpPerCapitaEntity) entity;
                if (!allCountryInfo.ContainsKey(gdpPerCapitaEntity.CountryCode))
                    allCountryInfo.Add(gdpPerCapitaEntity.CountryCode, new Dictionary<int, CountryInformationEntity>());
                if (!allCountryInfo[gdpPerCapitaEntity.CountryCode].ContainsKey(gdpPerCapitaEntity.Year))
                    allCountryInfo[gdpPerCapitaEntity.CountryCode]
                        .Add(gdpPerCapitaEntity.Year, new CountryInformationEntity {Year = gdpPerCapitaEntity.Year});
                allCountryInfo[gdpPerCapitaEntity.CountryCode][gdpPerCapitaEntity.Year].GdpPerCapita =
                    gdpPerCapitaEntity.Total;
            }
            repository = new PopulationRepository();
            Console.WriteLine("Doing population");

            foreach (var entity in repository.GetAll())
            {
                var populationEntity = (PopulationEntity) entity;
                if (!allCountryInfo.ContainsKey(populationEntity.CountryCode))
                    allCountryInfo.Add(populationEntity.CountryCode, new Dictionary<int, CountryInformationEntity>());
                if (!allCountryInfo[populationEntity.CountryCode].ContainsKey(populationEntity.Year))
                    allCountryInfo[populationEntity.CountryCode]
                        .Add(populationEntity.Year, new CountryInformationEntity {Year = populationEntity.Year});
                allCountryInfo[populationEntity.CountryCode][populationEntity.Year].Population =
                    populationEntity.Value;
            }
            repository = new InterestRepository();
            Console.WriteLine("Doing interest");

            foreach (var entity in repository.GetAll())
            {
                var interestEntity = (InterestEntity) entity;
                if (!allCountryInfo.ContainsKey(interestEntity.CountryCode))
                    allCountryInfo.Add(interestEntity.CountryCode, new Dictionary<int, CountryInformationEntity>());
                if (!allCountryInfo[interestEntity.CountryCode].ContainsKey(interestEntity.Year))
                    allCountryInfo[interestEntity.CountryCode]
                        .Add(interestEntity.Year, new CountryInformationEntity {Year = interestEntity.Year});
                allCountryInfo[interestEntity.CountryCode][interestEntity.Year].Interest =
                    interestEntity.Value;
            }
            repository = new ReligionRepository();
            Console.WriteLine("Doing religion");

            foreach (var entity in repository.GetAll())
            {
                var religionEntity = (ReligionEntity) entity;
                if (!allCountryInfo.ContainsKey(religionEntity.CountryCode))
                    allCountryInfo.Add(religionEntity.CountryCode, new Dictionary<int, CountryInformationEntity>());
                if (!allCountryInfo[religionEntity.CountryCode].ContainsKey(religionEntity.Year))
                    allCountryInfo[religionEntity.CountryCode]
                        .Add(religionEntity.Year, new CountryInformationEntity {Year = religionEntity.Year});
                allCountryInfo[religionEntity.CountryCode][religionEntity.Year].ChrstTotal =
                    religionEntity.ChrstTotal;
                allCountryInfo[religionEntity.CountryCode][religionEntity.Year].ChrstCat =
                    religionEntity.ChrstCat;
                allCountryInfo[religionEntity.CountryCode][religionEntity.Year].ChrstProt =
                    religionEntity.ChrstProt;
                allCountryInfo[religionEntity.CountryCode][religionEntity.Year].ChrstOther =
                    religionEntity.ChrstOther;
                allCountryInfo[religionEntity.CountryCode][religionEntity.Year].JudTotal =
                    religionEntity.JudTotal;
                allCountryInfo[religionEntity.CountryCode][religionEntity.Year].IslmTotal =
                    religionEntity.IslmTotal;
                allCountryInfo[religionEntity.CountryCode][religionEntity.Year].BudTotal =
                    religionEntity.BudTotal;
                allCountryInfo[religionEntity.CountryCode][religionEntity.Year].NonTotal =
                    religionEntity.NonTotal;
                allCountryInfo[religionEntity.CountryCode][religionEntity.Year].Other =
                    religionEntity.Other;
            }
            repository = new WorkRepository();
            Console.WriteLine("Doing work");

            foreach (var entity in repository.GetAll())
            {
                var workEntity = (WorkEntity) entity;
                if (!allCountryInfo.ContainsKey(workEntity.CountryCode))
                    allCountryInfo.Add(workEntity.CountryCode, new Dictionary<int, CountryInformationEntity>());
                if (!allCountryInfo[workEntity.CountryCode].ContainsKey(workEntity.Year))
                    allCountryInfo[workEntity.CountryCode]
                        .Add(workEntity.Year, new CountryInformationEntity {Year = workEntity.Year});
                allCountryInfo[workEntity.CountryCode][workEntity.Year].MilitairPop =
                    workEntity.MilitairPop;
                allCountryInfo[workEntity.CountryCode][workEntity.Year].UrbanPop =
                    workEntity.UrbanPop;
            }
            repository = new TvRepository();
            Console.WriteLine("Doing tv");

            foreach (var entity in repository.GetAll())
            {
                var tvEntity = (TvEntity) entity;
                if (!allCountryInfo.ContainsKey(tvEntity.CountryCode))
                    allCountryInfo.Add(tvEntity.CountryCode, new Dictionary<int, CountryInformationEntity>());
                if (!allCountryInfo[tvEntity.CountryCode].ContainsKey(tvEntity.Year))
                    allCountryInfo[tvEntity.CountryCode]
                        .Add(tvEntity.Year, new CountryInformationEntity {Year = tvEntity.Year});
                allCountryInfo[tvEntity.CountryCode][tvEntity.Year].Tv =
                    tvEntity.Value;
            }

            var totalCountryInformationEntities = new Dictionary<string, TotalCountryInformationEntity>();
            foreach (var countryinfo in allCountryInfo)
            {
                foreach (var countryInformationEntity in countryinfo.Value)
                {
                    if (!totalCountryInformationEntities.ContainsKey(countryinfo.Key))
                        totalCountryInformationEntities.Add(countryinfo.Key, new TotalCountryInformationEntity
                        {
                            CountryCode = countryinfo.Key,
                            CountryName = Iso3166Repository.GetCountryName(countryinfo.Key),
                            InformationEntities = new List<CountryInformationEntity>()
                        });
                    totalCountryInformationEntities[countryinfo.Key].InformationEntities
                        .Add(countryInformationEntity.Value);
                }
            }
            
            WriteEntitiesToJson(EntityNames.TotalCountryInformationEntities,totalCountryInformationEntities.Values.ToList());
        }
        
        

        protected static void WriteEntitiesToJson(EntityNames entityName, List<TotalCountryInformationEntity> entities)
        {
            var orderedByCoutry = SortByCountry(entities);
            foreach (var countryPair in orderedByCoutry)
            {
                CreateDirectoryIfNotExists();
                var resultFileName = CreateCurrentCountryFileName(entityName, countryPair.Key);

                SerializeFile(resultFileName, countryPair.Value);
            }
        }

        private static Dictionary<string, List<TotalCountryInformationEntity>> SortByCountry(
            IList<TotalCountryInformationEntity> allEntities)
        {
            var result = new Dictionary<string, List<TotalCountryInformationEntity>>();
            for (var i = 0; i < allEntities.Count; i++)
            {
                var entity = allEntities[i];

                if (!result.ContainsKey(entity.CountryCode))
                    result.Add(entity.CountryCode, new List<TotalCountryInformationEntity>());

                result[entity.CountryCode].Add(entity);
            }
            return result;
        }

        private static void CreateDirectoryIfNotExists()
        {
            if (!System.IO.Directory.Exists(Paths.ProcessedDataFolder))
                System.IO.Directory.CreateDirectory(Paths.ProcessedDataFolder);
        }

        private static string CreateCurrentCountryFileName(EntityNames entityName, string countryName)
        {
            return Paths.ProcessedDataFolder + Enum.GetName(typeof(EntityNames), entityName) + "_" + countryName
                   + ".json";
        }

        private static void SerializeFile(string fileName, List<TotalCountryInformationEntity> entityList)
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