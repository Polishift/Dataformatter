using System;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories.ModelFactories;
using Dataformatter.Dataprocessing.CsvParsing;
using Dataformatter.Dataprocessing.Processors;
using Dataformatter.Data_accessing.Repositories;

namespace Dataformatter
{
    internal static class Program
    {
        private static void Main()
        {
            #region ParseCode

//            const string electionsCsvLocation = "Datasources/Political/ElectionResults/election_data.csv";
//            const string partyClassificationCsvLocation = "Datasources/Political/PartyClassification/classificationData.csv";
//            const string turnoutCsvLocation = "Datasources/Political/Turnout/turnout_data.csv";

//            ICsvModelFactory<ConstituencyElectionModel> modelFactory =
//                new ConstituencyElectionModelFactory();

//            var allItemsAsModels = CsvToModel<ConstituencyElectionModel>.ParseAllCsvLinesToModels(
//                electionsCsvLocation, modelFactory);

//            var processor = new ElectionsProcessor();
//            processor.SerializeDataToJson(allItemsAsModels);

            #endregion

            var repo = new ElectionsRepository();
            foreach (var entity in repo.GetByCountry("NLD"))
            {
                //Console.WriteLine(entity);
            }
            
            //todo create loop for all countries and convert back to useable json with aplha3 value
            //const string countryinformationAfgGeoJson = "ProcessedData/CountryInformation/aia.geo.json";

            //todo actually fill in CountryGeoModel countrycode somehow, cunt    

            const string countryBorderDirectory = "ProcessedData/CountryInformation/";
            IJsonModelFactory<CountryGeoModel> countryGeoModelFactory = new CountryGeoModelFactory();
            AbstractDataProcessor<CountryGeoModel, CountryBordersEntity> countryBorderProcessor = new CountryBordersProcessor();

            var allCountryGeoModels = JsonToModel<CountryGeoModel>.ParseJsonDirectoryToModels(countryBorderDirectory, countryGeoModelFactory, "*.geo.json");
            countryBorderProcessor.SerializeDataToJson(allCountryGeoModels);
        }
    }
}