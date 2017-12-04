namespace Dataformatter.Datamodels
{
    public class WarModel : IModel
    {
        public string CountryName { get; set; }
        public string Name { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int Actors { get; set; }
    }
}