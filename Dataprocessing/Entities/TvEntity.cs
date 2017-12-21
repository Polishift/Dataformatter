namespace Dataformatter.Dataprocessing.Entities
{
    public class TvEntity : IEntity
    {
        public int Year { get; set; }
        public double Value { get; set; }
        public string CountryCode { get; set; }
    }
}