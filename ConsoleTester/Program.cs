﻿using DataDownloader;
using Dataformatter;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;
using Dataformatter.Data_accessing.Factories.ModelFactories;
using Dataformatter.Data_accessing.Filters;

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
            var workCsvLocation = Paths.RawDataFolder + @"\Economical & Social\NMC_5_0.csv";

            ICsvModelFactory<WorkModel> modelFactory =
                new WorkModelFactory();
            var allItemsAsModels = CsvToModel<WorkModel>.ParseAllCsvLinesToModels(
                workCsvLocation, modelFactory);
            var processor = new WorkProcessor();
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

/*
            IFilter filter = new YearFilter();
            filter.Filter();

            filter = new EuropeFilter();
            filter.Filter();
*/

            #endregion

            Downloader.DownloadData(Paths.ProcessedDataFolder);
        }
    }
}