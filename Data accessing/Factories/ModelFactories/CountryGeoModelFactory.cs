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
            var type  = JObject.FromObject(innerbody.GetValue("geometry")).GetValue("type").ToString();
            var list = new List<Polygon>();
            if (type.Equals("Polygon"))
            {
                Console.WriteLine(JObject.FromObject(innerbody.GetValue("geometry")).GetValue("coordinates"));
//                list.Add();
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