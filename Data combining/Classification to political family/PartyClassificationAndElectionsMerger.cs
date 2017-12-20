using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Repositories;
using Newtonsoft.Json;

namespace Dataformatter.Data_combining.Classification_to_political_family
{
    /*
    Summary: Connects the Party classification dataset (which uses the abrevviations of political parties)
             to the election results dataset, in which each party has it's full name.
    
    Returns: Two files per country: PartyFamilies_COUNTRY.json, which contains the full names of each party along with their classifications,
             and Election_COUNTRY.json, which contains the same Election JSON as before, but now with the classifications added.
    */
    public class PartyClassificationAndElectionsMerger
    {
        public static Dictionary<string, PartyFamilyEntity> PoliticalFamilyPerPartyInCurrentCountry;

        private readonly List<string> _allCountriesWithElections;
        private readonly HashSet<string> _countriesWithClassifiedParties;
        private readonly ElectionsRepository _electionsRepository = new ElectionsRepository();

        private readonly PartyClassificationRepository _partyclassificationRepository =
            new PartyClassificationRepository();

        private string _currentCountryCode;
        private ElectionEntity[] _currentCountryElectionsResultsPerParty;
        private PartyClassificationEntity[] _toBeConnectedClassificationEntitiesForCurrentCountry;


        public PartyClassificationAndElectionsMerger()
        {
            _allCountriesWithElections = _electionsRepository.GetCountryNames();
            _countriesWithClassifiedParties = new HashSet<string>(PartyClassificationRepository.GetCountryNames());
        }


        public void MergeIndividualCountry()
        {
            while (true)
            {
                Console.WriteLine("Please input the alpha3 code of the country you wish to classify: ");
                var countryCode = Console.ReadLine();

                MergeCountry(countryCode);

                Console.WriteLine("Done! Do you want to classify another one? (y/n)");
                var yesOrNo = Console.ReadLine();

                if (yesOrNo.ToLower().Equals("y"))
                    continue;
                Console.WriteLine("Okay, goodbye then");
                break;
            }
        }

        public void MergeAllCountries()
        {
            foreach (var currentCountry in _allCountriesWithElections)
                MergeCountry(currentCountry);
            Console.WriteLine("===================================");
            Console.WriteLine("           ALL DONE!            ");
            Console.WriteLine("===================================");
        }

        private void MergeCountry(string countryCode)
        {
            if (_countriesWithClassifiedParties.Contains(countryCode))
            {
                _currentCountryCode = countryCode;
                _currentCountryElectionsResultsPerParty = _electionsRepository.GetByCountry(_currentCountryCode);

                Console.WriteLine("-------------------------------");
                Console.WriteLine("Now doing " + _currentCountryCode);
                Console.WriteLine("-------------------------------");

                PoliticalFamilyPerPartyInCurrentCountry =
                    PartyFamiliesRepository.GetDictionaryByCountry(_currentCountryCode);
                _toBeConnectedClassificationEntitiesForCurrentCountry =
                    _partyclassificationRepository.GetByCountry(_currentCountryCode);

                ClassifyPartiesOfCurrentCountry();

                WriteNewPartyFamiliesToFile();
                WriteElectionsIncludingClassificationsToFile();

                Console.WriteLine("-------------------------------");
                Console.WriteLine("Done for " + _currentCountryCode);
                Console.WriteLine("-------------------------------");
            }
            else
            {
                Console.WriteLine("Country code " + countryCode + " unknown, skipping.");
            }
        }


        private void ClassifyPartiesOfCurrentCountry()
        {
            foreach (var electionResultForParty in _currentCountryElectionsResultsPerParty)
            {
                //Takes the CountryElection entity, matches its party to a classification entity.
                //Returns the same entry, but with its abbreviation and classification set.
                var abreviationToNameMatcher = new PartyNameToAbbreviationConnector(electionResultForParty,
                    _toBeConnectedClassificationEntitiesForCurrentCountry);
                var resultForPartyWithAbrevAndClassification =
                    abreviationToNameMatcher.GetElectionResultWithAbreviationAndClassification();

                //connecting classification to family using the now known abbreviation of the family entry
                var classificationToElectionResultConnector =
                    new ClassificationToElectionResultConnector(_toBeConnectedClassificationEntitiesForCurrentCountry);
                resultForPartyWithAbrevAndClassification =
                    classificationToElectionResultConnector.Connect(resultForPartyWithAbrevAndClassification);

                //if the classification is still not known.. the user should input it manually
                resultForPartyWithAbrevAndClassification = ManuallyClassify(resultForPartyWithAbrevAndClassification);

                //Finally after all is done, we update the electionResultForParty with the abrevviation and classification that we found for it :)
                electionResultForParty.PartyAbbreviation = resultForPartyWithAbrevAndClassification.PartyAbbreviation;
                electionResultForParty.PartyClassification =
                    resultForPartyWithAbrevAndClassification.PartyClassification;
            }
        }

        private static ElectionEntity ManuallyClassify(ElectionEntity electionResultForParty)
        {
            if (PoliticalFamilyPerPartyInCurrentCountry[electionResultForParty.PartyName] != null
                && PoliticalFamilyPerPartyInCurrentCountry[electionResultForParty.PartyName].Classification != null)
            {
                electionResultForParty.PartyClassification =
                    PoliticalFamilyPerPartyInCurrentCountry[electionResultForParty.PartyName].Classification;
            }
            else
            {
                Console.WriteLine("Enter a classification for " + electionResultForParty.PartyName);
                var manualClassification = Console.ReadLine();

                PoliticalFamilyPerPartyInCurrentCountry[electionResultForParty.PartyName].Classification =
                    manualClassification;
                electionResultForParty.PartyClassification = manualClassification;
            }
            return electionResultForParty;
        }


        private void WriteNewPartyFamiliesToFile()
        {
            //write party families to file
            using (var file =
                File.CreateText(Paths.ProcessedDataFolder + "PartyFamilies_" + _currentCountryCode + ".json"))
            {
                var classifciations = PoliticalFamilyPerPartyInCurrentCountry.Values.ToList();
                var serializer = new JsonSerializer();
                serializer.Serialize(file, classifciations);
            }
        }

        private void WriteElectionsIncludingClassificationsToFile()
        {
            //write election info, whose parties now have their families associated with them, to file
            using (var file = File.CreateText(Paths.ProcessedDataFolder + "Election_" +
                                              _currentCountryElectionsResultsPerParty[0].CountryCode + ".json"))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, _currentCountryElectionsResultsPerParty);
            }
        }
    }
}