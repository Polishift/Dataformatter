using System.Collections.Generic;

namespace Dataformatter.Dataprocessing.Entities
{
    class ElectionEntity : IEntity
    {
        public int Year { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public string PartyName { get; set; }
        public string PartyClassification { get; set; }
        public HashSet<string> PartyCandidates { get; set; }

        public double TotalAmountOfVotes { get; set; } //Has to be double in order for certain calculations to go well at small margins
        public double TotalVotePercentage { get; set; }
        public int TotalAmountOfSeatsGained { get; set; }
    }
}