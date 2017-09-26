namespace Dataformatter.Datamodels
{
    class ConstituencyElectionModel : IModel
    {
        public int Year { get; set; }
        public string CountryName { get; set; }
        public string PartyName { get; set; }
        public string CandidateName { get; set; }
        public double VoteFraction { get; set; }
        public double SecondRoundVoteFraction { get; set; }
        public int SeatsGained { get; set; }
    }
}
