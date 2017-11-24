using System;
using System.IO;
using Dataformatter;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;
using Dataformatter.Data_accessing.Factories.ModelFactories;
using Dataformatter.Data_accessing.Filters;
using Dataformatter.Data_accessing.Repositories;
using Microsoft.SqlServer.Server;

namespace ConsoleTester
{
    internal static class Program
    {
        private static void Main()
        {
            Paths.SetProcessedDataFolder(@"C:\Users\ceesj\Documents\hogeschool\minor\Code\ProcessedData\");
            Paths.SetRawDataFolder(@"C:\Users\ceesj\Documents\hogeschool\minor\Code\Datasources\");

            #region ParseCode

//             var electionsCsvLocation = Paths.RawDataFolder +  @"\Political\ElectionResults\election_data.csv";
//             var partyClassificationCsvLocation = Paths.RawDataFolder + @"\Political\PartyClassification\classificationData.csv";
//             var turnoutCsvLocation = Paths.RawDataFolder +  @"\Political\Turnout\turnout_data.csv";
            var employmentCsvLocation = Paths.RawDataFolder + @"\Economical & Social\Employment\employment.csv";
//            var religionCsvLocation = Paths.RawDataFolder + @"\Economical & Social\Religion\religion_data.csv";


            ICsvModelFactory<EmploymentModel> modelFactory =
                new EmploymentModelFactory();
            //
            var allItemsAsModels = CsvToModel<EmploymentModel>.ParseAllCsvLinesToModels(
                employmentCsvLocation, modelFactory);

            var processor = new EmploymentProcessor();
            processor.SerializeDataToJson(allItemsAsModels);

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

//            IFilter filter = new YearFilter();
//            filter.Filter();

//            filter = new EuropeFilter();
//            filter.Filter();

            #endregion

//            PartyClassificationMerge.Merge();
        }
    }
}