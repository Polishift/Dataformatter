using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Newtonsoft.Json.Linq;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class CountryGeoModelFactory : IJsonModelFactory<CountryGeoModel>
    {
        public CountryGeoModel Create(JObject jObject)
        {
            Console.WriteLine("here");
            var innerbody = JObject.FromObject(JArray.FromObject(jObject.GetValue("features")).First);
            var type = JObject.FromObject(innerbody.GetValue("geometry")).GetValue("type").ToString();
            var list = new List<Polygon>();
            if (type.Equals("Polygon"))
            {
                var coordinateArray = JArray.FromObject(JArray
                    .FromObject(JObject.FromObject(innerbody.GetValue("geometry")).GetValue("coordinates")).First);

                var coordinates = new List<IPoint>();
                foreach (var jToken in coordinateArray)
                {
                    var newPoint = new LatLongPoint
                    {
                        X = float.Parse(jToken.First.ToString()),
                        Y = float.Parse(jToken.Last.ToString())
                    };
                    coordinates.Add(newPoint);
                    Console.WriteLine(newPoint);
                }

                list.Add(new Polygon(coordinates));
            }
            else
            {
                //todo loop through coorddinates
            }
            return new CountryGeoModel
            {
                CountryName = JObject.FromObject(innerbody.GetValue("properties")).GetValue("cca2").ToString(),
                Polygons = list
            };
        }
    }
}