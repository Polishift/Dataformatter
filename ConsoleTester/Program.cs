using System;
using System.IO;
using Dataformatter;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;
using Dataformatter.Data_accessing.Factories.ModelFactories;
using Dataformatter.Data_accessing.Filters;
using Dataformatter.Data_accessing.Repositories;
using Dataformatter.Data_combining.Classification_to_political_family;
using Microsoft.SqlServer.Server;

namespace ConsoleTester
{
    internal static class Program
    {
        private static void Main()
        {
            Paths.SetProcessedDataFolder(@"C:\Users\ceesj\Documents\hogeschool\minor\Code\ProcessedData\");
            Paths.SetRawDataFolder(@"C:\Users\ceesj\Documents\hogeschool\minor\Code\Datasources\");

//            Paths.SetProcessedDataFolder(@"E:\Hogeschool\Polishift Organization\ProcessedData\");
//            Paths.SetRawDataFolder(@"E:\Hogeschool\Polishift Organization\Datasources\");


            #region ParseCode

//             var electionsCsvLocation = Paths.RawDataFolder +  @"\Political\ElectionResults\election_data.csv";
//           var partyClassificationCsvLocation = Paths.RawDataFolder + @"/Political/PartyClassification\classificationData.csv";
//             var turnoutCsvLocation = Paths.RawDataFolder +  @"\Political\Turnout\turnout_data.csv";
//            ICsvModelFactory<ConstituencyElectionModel> modelFactory =
//                new ConstituencyElectionModelFactory();
//            //
//            var allItemsAsModels = CsvToModel<ConstituencyElectionModel>.ParseAllCsvLinesToModels(
//                electionsCsvLocation, modelFactory);
//
//            var processor = new ElectionsProcessor();
//            processor.SerializeDataToJson(allItemsAsModels);

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

            //IFilter filter = new YearFilter();
            //filter.Filter();

//            filter = new EuropeFilter();
//            filter.Filter();

            #endregion

            var partyClassificationAndElectionsMerger = new PartyClassificationAndElectionsMerger();
            partyClassificationAndElectionsMerger.Merge();
        }
    }
}