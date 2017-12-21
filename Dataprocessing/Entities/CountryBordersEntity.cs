using System.Collections.Generic;
using Dataformatter.Datamodels;

namespace Dataformatter.Dataprocessing.Entities
{
    public class CountryBordersEntity : IEntity
    {
        public List<Polygon<XYPoint>> Polygons { get; set; }
        public string CountryCode { get; set; }
    }
}