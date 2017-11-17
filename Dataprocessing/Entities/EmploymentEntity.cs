namespace Dataformatter.Dataprocessing.Entities
{
    public class EmploymentEntity : IEntity
    {        
        public string CountryCode { get; set; }
        public int Year { get; set; }
        public double EmployedPercentage { get; set; }
    }
}