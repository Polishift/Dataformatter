namespace Dataformatter.Dataprocessing.Entities
{
    public class GdpTotalEntity : IEntity
    {
        public int Year { get; set; }
        public int Total { get; set; }
        public string CountryCode { get; set; }
    }
}