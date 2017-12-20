namespace Dataformatter.Dataprocessing.Entities
{
    public class GdpTotalEntity : IEntity
    {
        public string CountryCode { get; set; }
        public int Year { get; set; }
        public int Total { get; set; }
    }
}