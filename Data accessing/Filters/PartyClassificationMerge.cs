using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Processors;
using Dataformatter.Data_accessing.Repositories;
using Newtonsoft.Json;

namespace Dataformatter.Data_accessing.Filters
{
    public static class PartyClassificationMerge
    {
        public static void Merge()
        {
            var electionsRepository = new ElectionsRepository();
            var partyclassificationRepository = new PartyClassificationRepository();
            var classficiationRepository = new ClassificationRepository();

            var electionCountries = electionsRepository.GetCountryNames();

            var classificationCountries = new HashSet<string>(partyclassificationRepository.GetCountryNames());
            foreach (var electionCountry in electionCountries)
            {
                var countryElections = electionsRepository.GetByCountry(electionCountry);

                if (classificationCountries.Contains(electionCountry))
//                if (electionCountry.Equals("NLD"))
                {
                    Console.WriteLine("now doing " + electionCountry);
                    var partycodes = classficiationRepository.GetDictionaryByCountry(electionCountry);
                    var classificationlist = partyclassificationRepository.GetByCountry(electionCountry);

                    foreach (var countryElection in countryElections)
                    {
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
                                var abbreviationLine = Console.ReadLine();
                                partycodes.Add(countryElection.PartyName, new ClassificationEntity
                                {
                                    Abbreviation = abbreviationLine,
                                    CountryCode = electionCountry,
                                    PartyName = countryElection.PartyName
                                });
                                countryElection.PartyAbbreviation = abbreviationLine;
                            }
                            else
                            {
                                Console.WriteLine("got " + partycodes[countryElection.PartyName] + " for " +
                                                  countryElection.PartyName);
                                countryElection.PartyAbbreviation = partycodes[countryElection.PartyName].Abbreviation;
                            }
                        }

                        //connection classification using the now known abbreviation
                        foreach (var partyClassificationEntity in classificationlist)
                        {
                            if (!partyClassificationEntity.Name.Equals(countryElection.PartyAbbreviation,
                                StringComparison.CurrentCultureIgnoreCase)) continue;
                            if (!partyClassificationEntity.Classification.Equals("no family"))
                            {
                                Console.WriteLine("found correct one by " + countryElection.PartyName + " < > " +
                                                  partyClassificationEntity.Name + " <> " +
                                                  partyClassificationEntity.Classification);
                                countryElection.PartyClassification = partyClassificationEntity.Classification;
                                partycodes[countryElection.PartyName].Classification =
                                    partyClassificationEntity.Classification;
                                break;
                            }
                        }

                        //if the classification is still not known.. the user should input.
                        if (!countryElection.PartyClassification.Equals("Unknown")) continue;

                        if (partycodes[countryElection.PartyName] != null)
                        {
                            countryElection.PartyClassification = partycodes[countryElection.PartyName].Classification;
                            continue;
                        }
                        Console.WriteLine("Enter a classification for " + countryElection.PartyName + " (" +
                                          countryElection.Year + ")");
                        var classifcationLine = Console.ReadLine();
                        partycodes[countryElection.PartyName].Classification = classifcationLine;
                        countryElection.PartyClassification = classifcationLine;
                    }

                    //write party families to file
                    using (var file =
                        File.CreateText(Paths.ProcessedDataFolder+ "PartyFamilies_" + electionCountry +
                                        ".json"))
                    {
                        var classifciations = partycodes.Values.ToList();
                        var serializer = new JsonSerializer();
                        serializer.Serialize(file, classifciations);
                    }

                    //write election info to file
                    using (var file =
                        File.CreateText( Paths.ProcessedDataFolder+ "Election_" + countryElections[0].CountryCode +
                                        ".json"))
                    {
                        var serializer = new JsonSerializer();
                        serializer.Serialize(file, countryElections);
                    }
                }
            }
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
    }
}