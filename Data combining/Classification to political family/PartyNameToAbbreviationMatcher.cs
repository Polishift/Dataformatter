using System;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_combining.Classification_to_political_family
{
    public class PartyNameToAbbreviationConnector
    {
        private readonly PartyClassificationEntity[] _allPartyClassificationsInCountry;
        private readonly ElectionEntity _originalElectionResultForParty;


        public PartyNameToAbbreviationConnector(ElectionEntity originalElectionResultForParty,
            PartyClassificationEntity[] allPartyClassificationsInCountry)
        {
            _originalElectionResultForParty = originalElectionResultForParty;
            _allPartyClassificationsInCountry = allPartyClassificationsInCountry;
        }

        public ElectionEntity GetElectionResultWithAbreviationAndClassification()
        {
            Console.WriteLine("Gonna abbreviate " + _originalElectionResultForParty.PartyName);
            var strippedName = AbbreviatePartyName(_originalElectionResultForParty.PartyName);

            //examine each partyClassifications abrevviation to see if it matches with the full name of the originalElectionResultForParty
            foreach (var partyClassificationEntity in _allPartyClassificationsInCountry)
            {
                //If the abrevviation and the name are the same or the abrevviation is COMPLETELY unknown, no further matching is needed.
                if (!partyClassificationEntity.Name.Equals(strippedName, StringComparison.CurrentCultureIgnoreCase))
                    continue;


                Console.WriteLine("found correct abbreviation/name combo by "
                                  + _originalElectionResultForParty.PartyName + " < > " +
                                  partyClassificationEntity.Name);

                _originalElectionResultForParty.PartyAbbreviation = partyClassificationEntity.Name;
                _originalElectionResultForParty.PartyClassification = partyClassificationEntity.Classification;
                break;
            }

            //if the abrevviation of the political family entry for this party is the same as the party's full name, we just set the _originalElectionResultForParty's name to that abrevviation.
            if (PartyClassificationAndElectionsMerger.PoliticalFamilyPerPartyInCurrentCountry.ContainsKey(
                _originalElectionResultForParty.PartyName))
            {
                Console.WriteLine(
                    "got " + PartyClassificationAndElectionsMerger
                        .PoliticalFamilyPerPartyInCurrentCountry[_originalElectionResultForParty.PartyName]
                        .Abbreviation + " for " + _originalElectionResultForParty.PartyName);

                _originalElectionResultForParty.PartyAbbreviation = PartyClassificationAndElectionsMerger
                    .PoliticalFamilyPerPartyInCurrentCountry[_originalElectionResultForParty.PartyName].Abbreviation;
            }
            else //if the above is not the case, the abrevviation is completely unknown and the user has to input it.
            {
                Console.WriteLine("Enter a abbreviation for " + _originalElectionResultForParty.PartyName);

                var abbreviationLine = Console.ReadLine();
                PartyClassificationAndElectionsMerger.PoliticalFamilyPerPartyInCurrentCountry.Add(
                    _originalElectionResultForParty.PartyName,
                    new PartyFamilyEntity
                    {
                        Abbreviation = abbreviationLine,
                        CountryCode = _originalElectionResultForParty.CountryCode,
                        PartyName = _originalElectionResultForParty.PartyName
                    });

                _originalElectionResultForParty.PartyAbbreviation = abbreviationLine;
            }
            return _originalElectionResultForParty;
        }


        private static string AbbreviatePartyName(string partyName)
        {
            var partyWithoutYear = partyName;
            if (partyName.Contains("(1"))
                partyWithoutYear = partyName.Substring(0, partyName.IndexOf("(1", StringComparison.InvariantCulture));


            var parts = partyWithoutYear.Split(' ');

            var result = "";
            foreach (var part in parts)
                try
                {
                    result = result + part[0];
                }
                catch (Exception e)
                {
                    // ignored
                }
            return result;
        }
    }
}