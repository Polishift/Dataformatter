namespace Dataformatter.Datamodels
{
    public class EmploymentModel : IModel
    {
        public string CountryName { get; set; }
        public int Year { get; set; }
        public double EmployedPercentage { get; set; }
    }
}