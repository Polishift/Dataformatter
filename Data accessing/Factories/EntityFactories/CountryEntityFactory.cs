using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class CountryEntityFactory : EntityFactory<CountryGeoModel, CountryBordersEntity>
    {
        private static readonly double MINIMUM_POINT_X_DISTANCE = 0.0005;

        public override CountryBordersEntity Create(CountryGeoModel rawModel)
        {
            var convertedPolygons = new List<Polygon<XYPoint>>();

            for (var j = 0; j < rawModel.Polygons.Count; j++)
            {
                var convertedPolygon = new Polygon<XYPoint>();
                var currentPolygon = rawModel.Polygons[j];

                convertedPolygon.Points = GetXYPointsFromLatLongs(currentPolygon.Points);
                convertedPolygons.Add(convertedPolygon);
            }

            return new CountryBordersEntity
            {
                Polygons = convertedPolygons,
                CountryCode = CreateCountryCode(rawModel.CountryName)
            };
        }

        public static List<XYPoint> GetXYPointsFromLatLongs(List<LatLongPoint> latLongs)
        {
            var xyPointsForLatLongs = new List<XYPoint>();

            foreach (var latLong in latLongs)
            {
                var xyPointForCurrentLatLong = latLong.ToXYPoint();
                xyPointsForLatLongs.Add(xyPointForCurrentLatLong);
            }
            return xyPointsForLatLongs;
        }
    }
}