namespace Dataformatter.Dataprocessing.Entities
{
    public class PopulationEntity : IEntity
    {
        public string CountryCode { get; set; }
        public int Year { get; set; }
        public int Value { get; set; }
    }
}