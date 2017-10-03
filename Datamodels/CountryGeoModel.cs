using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Datamodels
{
    public class CountryGeoModel : IModel
    {
        public string CountryName { get; set; }
        public List<Polygon> Polygons { get; set; }

        public override string ToString()
        {
            var listString = "";
            foreach (var polygon in Polygons)
                listString = listString + "\n" + polygon.ToString();
            return CountryName +  " " + listString;
        }
    }
}