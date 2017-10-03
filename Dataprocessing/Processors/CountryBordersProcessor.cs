using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories;
using Dataformatter.Data_accessing.Factories.EntityFactories;
using Newtonsoft.Json;

namespace Dataformatter.Dataprocessing.Processors
{
    class CountryBordersProcessor : AbstractDataProcessor<CountryGeoModel,  
                                                          CountryBordersEntity>
    {
        public override void SerializeDataToJson(List<CountryGeoModel> rawModels)
        {
            var countryBordersEntities = new List<CountryBordersEntity>();

            for(var i = 0; i < rawModels.Count; i++)
            {
                var convertedPolygons = new List<Polygon>();

                for(var j = 0; j < rawModels[i].Polygons.Count; j++)
                {
                    var currentConvertedPolygon = new Polygon();
                    var currentPolygon = rawModels[i].Polygons[j];

                    var xyPointsForLatLongs = new List<IPoint>();                
                    currentPolygon.Points.ForEach(p => xyPointsForLatLongs.Add(ConvertTo2DPoint(p)));

                    currentConvertedPolygon.Points = xyPointsForLatLongs;
                    convertedPolygons.Add(currentConvertedPolygon);
                }
            }
            WriteEntitiesToJson(EntityNames.CountryBorders, countryBordersEntities);
        }

        
        private static XYPoint ConvertTo2DPoint(IPoint latLong) //ew IPoint here
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