using System;
using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class DefaultCountryBordersEntityFactory : EntityFactory<CountryGeoModel, CountryBordersEntity>
    {
        public override CountryBordersEntity Create(CountryGeoModel rawModel)
        {
            var convertedPolygons = new List<Polygon<XYPoint>>();

            for (var j = 0; j < rawModel.Polygons.Count; j++)
            {
                var convertedPolygon = new Polygon<XYPoint>();
                var currentPolygon = rawModel.Polygons[j];

                var xyPointsForLatLongs = new List<XYPoint>();
                currentPolygon.Points.ForEach(p => xyPointsForLatLongs.Add(p.ToXYPoint()));

                convertedPolygon.Points = xyPointsForLatLongs;
                convertedPolygons.Add(convertedPolygon);
            }

            return new CountryBordersEntity
            {
                Polygons = convertedPolygons,
                CountryCode = CreateCountryCode(rawModel.CountryName)
            };
        }
    }
}