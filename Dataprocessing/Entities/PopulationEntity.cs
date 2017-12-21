namespace Dataformatter.Dataprocessing.Entities
{
    public class PopulationEntity : IEntity
    {
        public int Year { get; set; }
        public int Value { get; set; }
        public string CountryCode { get; set; }
    }
}