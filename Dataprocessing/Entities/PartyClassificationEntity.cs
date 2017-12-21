namespace Dataformatter.Dataprocessing.Entities
{
    public class PartyClassificationEntity : IEntity
    {
        public string Name { get; set; }
        public string Classification { get; set; }
        public string CountryCode { get; set; }
    }
}