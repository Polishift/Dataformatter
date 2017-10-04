using System.Collections.Generic;

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
                listString = listString + "\n" + polygon;
            return CountryName +  " " + listString;
        }
    }
}