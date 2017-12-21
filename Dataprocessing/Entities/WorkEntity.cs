namespace Dataformatter.Dataprocessing.Entities
{
    public class WorkEntity : IEntity
    {
        public int Year { get; set; }
        public int MilitairPop { get; set; }
        public int UrbanPop { get; set; }
        public string CountryCode { get; set; }
    }
}