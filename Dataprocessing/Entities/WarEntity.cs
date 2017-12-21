namespace Dataformatter.Dataprocessing.Entities
{
    public class WarEntity : IEntity
    {
        public string Name { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int Actors { get; set; }
        public string CountryCode { get; set; }
    }
}