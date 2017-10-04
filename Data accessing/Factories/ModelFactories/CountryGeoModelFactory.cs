﻿using System;
using System.Collections.Generic;
using Dataformatter.Datamodels;
using Newtonsoft.Json.Linq;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class CountryGeoModelFactory : IJsonModelFactory<CountryGeoModel>
    {
        //bad: cuw, ssd, sxm, unk
        public CountryGeoModel Create(JObject jObject)
        {
            var innerbody = JObject.FromObject(JArray.FromObject(jObject.GetValue("features")).First);
            var type = JObject.FromObject(innerbody.GetValue("geometry")).GetValue("type").ToString();
            var country = JObject.FromObject(innerbody.GetValue("properties")).GetValue("cca2").ToString();
            var polygons = new List<Polygon>();

            //todo make this generic..
            if (type.Equals("Polygon"))
            {
                var coordinateArray = JArray.FromObject(JArray
                    .FromObject(JObject.FromObject(innerbody.GetValue("geometry")).GetValue("coordinates")).First);

                var coordinateList = new List<IPoint>();
                foreach (var coordinates in coordinateArray)
                {
                    var newPoint = new LatLongPoint
                    {
                        X = float.Parse(coordinates.First.ToString()),
                        Y = float.Parse(coordinates.Last.ToString())
                    };
                    coordinateList.Add(newPoint);
                }
                polygons.Add(new Polygon(coordinateList));
            }
            else
            {
                var coordinateArray = JArray.FromObject(JArray
                    .FromObject(JObject.FromObject(innerbody.GetValue("geometry")).GetValue("coordinates")));
                foreach (var jToken in coordinateArray)
                {
                    var coordinateList = new List<IPoint>();
                    foreach (var coordinates in jToken.First)
                    {
                        var newPoint = new LatLongPoint
                        {
                            X = float.Parse(coordinates.First.ToString()),
                            Y = float.Parse(coordinates.Last.ToString())
                        };
                        coordinateList.Add(newPoint);
                    }
                    polygons.Add(new Polygon(coordinateList));
                }
            }
            return new CountryGeoModel
            {
                CountryName = country,
                Polygons = polygons
            };
        }
    }
}