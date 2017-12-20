using System.Collections.Generic;

namespace Dataformatter.Datamodels
{
    public class WorkModel : IModel
    {
        public string CountryName { get; set; }
        public int Year { get; set; }
        public double MilitairPop { get; set; }
        public double UrbanPop { get; set; }
    }
}