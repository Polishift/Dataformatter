using System;
using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Parsing;
using Newtonsoft.Json;

namespace Dataformatter.Data_accessing.Repositories
{
    public static class Iso3166Repository 
    {
        private const string FileName = "countries.json";

        private static Iso3166Country[] Collection;
            

        static Iso3166Repository()
        {
            //This really needs to happen in a Dataformatter global init function somewhere else
            
            //Avoiding nullpointers when Paths arent yet set.
            if(Dataformatter.Paths.RawDataFolder != null && Dataformatter.Paths.ProcessedDataFolder!= null)
                InitializeCollection();
            else
                 Console.WriteLine("WARNING: JsonReader Paths not set! Collection won't be initialized.");               
        }

        public static void InitializeCollection()
        {
            Collection = JsonReader<Iso3166Country>.ParseJsonToListOfObjects(FileName);
        }

        public static Iso3166Country[] GetCollection()
        {
            return Collection;
        }
        

        /// <summary>
        /// Obtain ISO3166-1 Country based on its alpha3 code.
        /// </summary>
        /// <param name="alpha3"></param>
        /// <returns></returns>
        public static Iso3166Country FromAlpha3(string alpha3)
        {
            return Collection.FirstOrDefault(p => p.Alpha3 == alpha3);
        }

        /// <summary>
        /// Obtain ISO3166-1 Country based on its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Iso3166Country FromName(string name)
        {
            return Collection.FirstOrDefault(p => p.Name == name);
        }

        /// <summary>
        /// Obtain ISO3166-1 Country based on its alpha2 code.
        /// </summary>
        /// <param name="alpha2"></param>
        /// <returns></returns>
        public static Iso3166Country FromAlpha2(string alpha2)
        {
            return Collection.FirstOrDefault(p => p.Alpha2 == alpha2);
        }

        /// <summary>
        /// Obtain ISO3166-1 Country based on alternative names for the country.
        /// </summary>
        /// <param name="alternative"></param>
        /// <returns></returns>
        public static Iso3166Country FromAlternativeName(string alternative)
        {
            for (var i = 0; i < Collection.Length; i++)
            {
                var item = Collection.ElementAt(i);
                if (item.AlternativeNames == null) continue;
                if (item.AlternativeNames.Contains(alternative))
                    return item;
            }
            return null;
        }
    }

    /// <summary>
    /// Representation of an ISO3166-1 Country
    /// </summary>
    public class Iso3166Country
    {
        public Iso3166Country(string name, string alpha2, string alpha3)
        {
            Name = name.ToLower();
            Alpha2 = alpha2;
            Alpha3 = alpha3;
        }

        //needed for parsing countries.json
        [JsonConstructor]
        public Iso3166Country(string name, string alpha2, string alpha3,
            List<string> alternativeNames)
        {
            Name = name.ToLower();
            Alpha2 = alpha2;
            Alpha3 = alpha3;
            AlternativeNames = alternativeNames;
        }

        public readonly string Name;

        public readonly string Alpha2;

        public readonly string Alpha3;

        public readonly  List<string> AlternativeNames;

        public override string ToString()
        {
            return Name;
        }
    }
}