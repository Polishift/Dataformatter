﻿using System.Collections.Generic;
using System.Linq;

namespace Dataformatter.Datamodels
{
    public class CountryGeoModel : IModel
    {
        public List<Polygon<LatLongPoint>> Polygons { get; set; }
        public string CountryName { get; set; }

        public override string ToString()
        {
            var listString = Polygons.Aggregate("", (current, polygon) => current + "\n" + polygon);
            return CountryName + " " + listString;
        }
    }
}