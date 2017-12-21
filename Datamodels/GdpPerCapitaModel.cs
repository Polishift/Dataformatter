using System.Collections.Generic;

namespace Dataformatter.Datamodels
{
    public class GdpPerCapitaModel : IModel
    {
        public Dictionary<int, double> ValueByYear { get; set; }
        public string CountryName { get; set; }
    }
}