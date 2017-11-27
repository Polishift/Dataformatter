﻿using System;
using System.Linq;
using Dataformatter.Dataprocessing.Parsing;

namespace Dataformatter.Data_accessing.Repositories
{
    public static class Iso3166Repository
    {
        private const string FileName = "countries.json";
        private static Iso3166Country[] Collection;

        static Iso3166Repository()
        {
            if (Paths.RawDataFolder != null && Paths.ProcessedDataFolder != null)
                InitializeCollection();
            else
                Console.WriteLine("WARNING: JsonReader Paths not set! Collection won't be initialized.");
        }

        public static void InitializeCollection()
        {
            Collection = JsonReader<Iso3166Country>.ParseJsonToListOfObjects("countries.json");
        }

        public static Iso3166Country[] GetCollection()
        {
            return Collection;
        }

        public static Iso3166Country FromAlpha3(string alpha3)
        {
            return Collection.FirstOrDefault(
                p => p.Alpha3 == alpha3);
        }

        public static Iso3166Country FromName(string name)
        {
            return Collection.FirstOrDefault(
                p => p.Name == name);
        }

        public static Iso3166Country FromAlpha2(string alpha2)
        {
            return Collection.FirstOrDefault(
                p => p.Alpha2 == alpha2);
        }

        public static Iso3166Country FromAlternativeName(string alternative)
        {
            for (var index = 0; index < Collection.Length; ++index)
            {
                var iso3166Country =
                    Collection.ElementAt(index);
                if (iso3166Country.AlternativeNames != null && iso3166Country.AlternativeNames.Contains(alternative))
                    return iso3166Country;
            }
            return null;
        }
    }
}