using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Data_accessing.Factories.ModelFactories;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;
using Dataformatter.Data_accessing.Repositories;
using Newtonsoft.Json;

namespace Dataformatter
{
    internal static class Program
    {
        private static void Main()
        {
            #region ParseCode

//
//            const string electionsCsvLocation = "Datasources/Political/ElectionResults/election_data.csv";
//            //            const string partyClassificationCsvLocation = "Datasources/Political/PartyClassification/classificationData.csv";
//            //            const string turnoutCsvLocation = "Datasources/Political/Turnout/turnout_data.csv";
//            //
//            ICsvModelFactory<ConstituencyElectionModel> modelFactory =
//                new ConstituencyElectionModelFactory();
//            //
//            var allItemsAsModels = CsvToModel<ConstituencyElectionModel>.ParseAllCsvLinesToModels(
//                electionsCsvLocation, modelFactory);
//
//            var processor = new ElectionsProcessor();
//            processor.SerializeDataToJson(allItemsAsModels);

            #endregion

            #region Repositry talking

            //var repo = new ElectionsRepository();
            //foreach (var entity in repo.GetByCountry("NLD"))
            //{
            //Console.WriteLine(entity);
            //}

            #endregion


            #region Parsing country borders

//            const string countryBorderDirectory = "ProcessedData/CountryInformation/";
//            IJsonModelFactory<CountryGeoModel> countryGeoModelFactory = new CountryGeoModelFactory();
//            var processor = new CountryBordersProcessor();
//
//            var allCountryGeoModels =
//                JsonToModel<CountryGeoModel>.ParseJsonDirectoryToModels(countryBorderDirectory, countryGeoModelFactory,
//                    "*.geo.json");
//            processor.SerializeDataToJson(allCountryGeoModels);
//
//            CountryBordersRepository countryBordersRepo = new CountryBordersRepository();
//            foreach (var country in countryBordersRepo.GetAll())
//            {
//                Console.WriteLine("Countrycode: " + country.CountryCode);    
//            }

            #endregion

            #region connectClassification

            var electionsRepository = new ElectionsRepository();
            var classificationRepository = new PartyClassificationRepository();

            var electionCountries = electionsRepository.GetCountryNames();
            var classificationCountries = new HashSet<string>(classificationRepository.GetCountryNames());

            foreach (var electionCountry in electionCountries)
            {
                var countryElections = electionsRepository.GetByCountry(electionCountry);

//                if (classificationCountries.Contains(electionCountry))
                if (electionCountry.Equals("NLD"))
                {
                    Console.WriteLine("now doing " + electionCountry);
                    var partycodes = new Dictionary<string, string>();
                    var classificationlist = classificationRepository.GetByCountry(electionCountry);

                    foreach (var countryElection in countryElections)
                    {
                        if (countryElection.Year < 1945) continue;
                        if (!countryElection.PartyClassification.Equals("Unknown")) continue;
                        var strippedName = StripPartyName(countryElection.PartyName);
                        foreach (var partyClassificationEntity in classificationlist)
                        {
                            if (!partyClassificationEntity.Name.Equals(strippedName,
                                StringComparison.CurrentCultureIgnoreCase)) continue;
                            if (!partyClassificationEntity.Classification.Equals("no family"))
                            {
                                Console.WriteLine("found correct one by " + countryElection.PartyName + " < > " +
                                                  partyClassificationEntity.Name);
                                countryElection.PartyAbbreviation = partyClassificationEntity.Name;
                                countryElection.PartyClassification = partyClassificationEntity.Classification;
                                //add to list
                            }
                            break;
                        }
                        if (!countryElection.PartyClassification.Equals("Unknown")) continue;

                        //connecting abbreviation to party
                        if (countryElection.PartyAbbreviation == null)
                        {
                            if (!partycodes.ContainsKey(countryElection.PartyName))
                            {
                                Console.WriteLine("Enter a abbreviation for " + countryElection.PartyName + " (" +
                                                  countryElection.Year + ")");
                                var info = Console.ReadLine();
                                partycodes.Add(countryElection.PartyName, info);
                                countryElection.PartyAbbreviation = info;
                            }
                            else
                            {
                                Console.WriteLine("got " + partycodes[countryElection.PartyName] + " for " +
                                                  countryElection.PartyName);
                                countryElection.PartyAbbreviation = partycodes[countryElection.PartyName];
                            }
                        }

                        foreach (var partyClassificationEntity in classificationlist)
                        {
                            if (!partyClassificationEntity.Name.Equals(countryElection.PartyAbbreviation,
                                StringComparison.CurrentCultureIgnoreCase)) continue;
                            if (!partyClassificationEntity.Classification.Equals("no family"))
                            {
                                Console.WriteLine("found correct one by " + countryElection.PartyName + " < > " +
                                                  partyClassificationEntity.Name);
                                countryElection.PartyClassification = partyClassificationEntity.Classification;
                            }
                            break;
                        }
                        
                        if (!countryElection.PartyClassification.Equals("Unknown")) continue;
                        Console.WriteLine("Enter a classification for " + countryElection.PartyName + " (" +
                                          countryElection.Year + ")");
                        
                        //todo connect classification manual.
                    }


                    using (var file =
                        File.CreateText("ProcessedData/Election_" + countryElections[0].CountryCode +
                                        ".json"))
                    {
                        var serializer = new JsonSerializer();
                        serializer.Serialize(file, countryElections);
                    }
                }
            }

            #endregion

//            Console.WriteLine("All done!");
        }

        private static string StripPartyName(string partyName)
        {
            var parts = partyName.Split(' ');
            var result = "";
            foreach (var part in parts)
            {
                try
                {
                    result = result + part[0];
                }
                catch (Exception e)
                {
                    // ignored
                }
            }
            return result;
        }

        private static string CreateCountryCode(string fullCountryName)
        {
            var result = Iso3166Repository.FromName(fullCountryName.ToLower()) ??
                         (Iso3166Repository.FromAlpha2(fullCountryName.ToUpper()) ??
                          Iso3166Repository.FromAlternativeName(fullCountryName.ToLower()) ??
                          Iso3166Repository.FromAlpha3(fullCountryName.ToUpper()));


            if (result != null) return result.Alpha3;
            Console.WriteLine("nothing found by " + fullCountryName);
            return new Iso3166Country("UNKNOWN", "UNKNOWN", "UNKNOWN").Alpha3;
        }
    }
}