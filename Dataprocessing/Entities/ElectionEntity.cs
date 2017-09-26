using System.Collections.Generic;

namespace Dataformatter.Dataprocessing.Entities
{
    class ElectionEntity
    {
        public int Year { get; set; }
        public string CountryCode { get; set; }

        public string PartyName { get; set; }
        public string PartyClassification { get; set; }
        public HashSet<string> PartyCandidates { get; set; }

        public double TotalVotePercentage { get; set; }
        public int TotalAmountOfSeatsGained { get; set; }
    }
}