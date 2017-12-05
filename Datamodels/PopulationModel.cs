using System.Collections.Generic;

namespace Dataformatter.Datamodels
{
    public class PopulationModel : IModel
    {
        public string CountryName { get; set; }
        public Dictionary<int, double> ValueByYear { get; set; }
    }
}