using System;
using System.Collections.Generic;
using Dataformatter.Data_accessing.Repositories;

namespace Dataformatter.Dataprocessing.Entities
{
    public class ElectionEntity : IEntity, ICountryRuler
    {
        public int Year { get; set; }
        public string CountryName { get; set; }

        public string PartyName { get; set; }
        public string PartyAbbreviation { get; set; }
        public string PartyClassification { get; set; }
        public HashSet<string> PartyCandidates { get; set; }

        public double
            TotalAmountOfVotes
        {
            get;
            set;
        } //Has to be double in order for certain calculations to go well at small margins

        public double TotalVotePercentage { get; set; }
        public int TotalAmountOfSeatsGained { get; set; }
        public string CountryCode { get; set; }


        public static ElectionEntity GetEmptyElectionEntity(Iso3166Country associatedCountry)
        {
            return new ElectionEntity
            {
                Year = 0,
                CountryCode = associatedCountry.Alpha3,
                CountryName = associatedCountry.Name,

                PartyName = "None",
                PartyAbbreviation = "NA",
                PartyClassification = "Unknown",
                PartyCandidates = new HashSet<string> {"No candidates found"},

                TotalAmountOfVotes = 0,
                TotalVotePercentage = 0.0,
                TotalAmountOfSeatsGained = 0
            };
        }

        public override string ToString()
        {
            return PartyName + ", who are '" + PartyClassification + "'. They gained " 
                   + GetFormattedVotePercentage() + "% of the votes.";
        }

        private string GetFormattedVotePercentage()
        {
            return $"{TotalVotePercentage:0.00}";
        }
    }
}