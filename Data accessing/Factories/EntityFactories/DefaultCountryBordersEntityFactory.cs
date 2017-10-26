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
                currentPolygon.Points.ForEach(p => xyPointsForLatLongs.Add(ConvertTo2DPoint(p)));

                convertedPolygon.Points = xyPointsForLatLongs;
                convertedPolygons.Add(convertedPolygon);
            }

            return new CountryBordersEntity
            {
                Polygons = convertedPolygons,
                CountryCode = CreateCountryCode(rawModel.CountryName)
            };
        }

        private static XYPoint ConvertTo2DPoint(IPoint latLong) //ew IPoint here
        {
            var x = Math.Cos(latLong.X) * Math.Cos(latLong.Y);
            var y = Math.Cos(latLong.X) * Math.Sin(latLong.Y);
            
            return new XYPoint { X = (float) x, Y = (float) y };
        }
    }
}