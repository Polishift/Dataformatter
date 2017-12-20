namespace Dataformatter.Datamodels
{
    public class InterestModel : IModel
    {
        public int Year { get; set; }
        public double Value { get; set; }
        public string CountryName { get; set; }
    }
}