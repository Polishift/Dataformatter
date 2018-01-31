namespace Dataformatter.Dataprocessing.Entities
{
    public class GdpPerCapitaEntity : IEntity
    {
        public int Year { get; set; }
        public int Total { get; set; }
        public string CountryCode { get; set; }
    }
}