namespace Dataformatter.Datamodels
{
    public class EmploymentModel : IModel
    {
        public int Year { get; set; }
        public double EmployedPercentage { get; set; }
        public string CountryName { get; set; }
    }
}