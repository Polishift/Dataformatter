namespace Dataformatter.Dataprocessing.Entities
{
    public class PartyFamilyEntity : IEntity
    {
        public string PartyName { get; set; }
        public string Abbreviation { get; set; }
        public string Classification { get; set; }
        public string CountryCode { get; set; }
    }
}