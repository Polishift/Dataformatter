namespace Dataformatter.Dataprocessing.Entities
{
    public class GdpPerCapitaEntity : IEntity
    {
        public string CountryCode { get; set; }
        public int Year { get; set; }
        public int Total { get; set; }
    }
}