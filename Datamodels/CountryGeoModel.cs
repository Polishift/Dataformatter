using System.Collections.Generic;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Datamodels
{
    public class CountryGeoModel : IModel
    {
        public string CountryName { get; set; }
        public List<Polygon> Polygons { get; set; }
    }
}