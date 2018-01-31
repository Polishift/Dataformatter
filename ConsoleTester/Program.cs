﻿﻿using System.Collections.Generic;
 using Dataformatter;
using Dataformatter.Datamodels;
 using Dataformatter.Dataprocessing.Entities;
 using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;
using Dataformatter.Data_accessing.Factories.ModelFactories;
using Dataformatter.Data_accessing.Filters;
  using Dataformatter.Data_combining.Classification_to_political_family;

namespace ConsoleTester
{
    internal static class Program
    {
        private static void Main()
        {
            //Paths.SetProcessedDataFolder(@"C:\Users\ceesj\Documents\hogeschool\minor\Code\ProcessedData\");
            //Paths.SetRawDataFolder(@"C:\Users\ceesj\Documents\hogeschool\minor\Code\Datasources\");

            Paths.SetProcessedDataFolder(@"E:\Hogeschool\Polishift Organization\ProcessedData\");
            Paths.SetRawDataFolder(@"E:\Hogeschool\Polishift Organization\Datasources\");

            #region ParseCode

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

            
            ICsvModelFactory<GdpPerCapitaModel> modelFactory =
                new GdpPerCapitaModelFactory();
            var allItemsAsModels = CsvToModel<GdpPerCapitaModel>.ParseAllCsvLinesToModels(
                gdpCapitaCsvLocation, modelFactory);
            
            var processor = new GdpPerCapitaProcessor();
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

            //IFilter filter = new YearFilter();
            //filter.Filter();

            //filter = new EuropeFilter();
            //filter.Filter();

            #endregion

            var partyClassificationAndElectionsMerger = new PartyClassificationAndElectionsMerger();
            partyClassificationAndElectionsMerger.MergeIndividualCountry();
        }
    }
}