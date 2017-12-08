namespace Dataformatter.Dataprocessing.Entities
{
    public class PopEntity : IEntity
    {
        public string CountryCode { get; set; }
        public int Year { get; set; }
        public int MilitairPop { get; set; }
        public int UrbanPop { get; set; }
        public int NonUrbanPop { get; set; }
    }
}