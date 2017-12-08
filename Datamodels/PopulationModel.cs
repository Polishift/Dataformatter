namespace Dataformatter.Datamodels
{
    public class PopModel : IModel
    {
        public string CountryName { get; set; }
        public int Year { get; set; }
        public int MilitairPop { get; set; }
        public int UrbanPop { get; set; }
        public int TotalPop { get; set; }
    }
}