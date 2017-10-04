using System;
using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    class DefaultCountryBordersEntityFactory : EntityFactory<CountryGeoModel, CountryBordersEntity>
    {
        public override CountryBordersEntity Create(CountryGeoModel rawModel)
        {
            var convertedPolygons = new List<Polygon>();

            for (var j = 0; j < rawModel.Polygons.Count; j++)
            {
                var currentConvertedPolygon = new Polygon();
                var currentPolygon = rawModel.Polygons[j];

                var xyPointsForLatLongs = new List<IPoint>();
                currentPolygon.Points.ForEach(p => xyPointsForLatLongs.Add(ConvertTo2DPoint(p)));

                currentConvertedPolygon.Points = xyPointsForLatLongs;
                convertedPolygons.Add(currentConvertedPolygon);
            }

            return new CountryBordersEntity
            {
                Polygons = convertedPolygons,
                CountryCode = rawModel.CountryName
            };
        }

        private XYPoint ConvertTo2DPoint(IPoint latLong) //ew IPoint here
        {
            const int rMajor = 6378137; //Equatorial Radius, WGS84
            const double shift = Math.PI * rMajor;

            var x = latLong.Y * shift / 180;
            var y = Math.Log(Math.Tan((90 + latLong.X) * Math.PI / 360)) / (Math.PI / 180);
            y = y * shift / 180;

            return new XYPoint { X = (float) x, Y = (float) y };
        }
    }
}