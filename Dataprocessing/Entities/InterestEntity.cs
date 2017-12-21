namespace Dataformatter.Dataprocessing.Entities
{
    public class InterestEntity : IEntity
    {
        public int Year { get; set; }
        public double Value { get; set; }
        public string CountryCode { get; set; }
    }
}