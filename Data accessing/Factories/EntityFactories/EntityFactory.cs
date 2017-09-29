using System;
using Dataformatter.Dataprocessing;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class EntityFactory
    {
        protected static string CreateCountryCode(string fullCountryName)
        {
            var result = Iso3166.FromName(fullCountryName.ToLower()) ??
                         (Iso3166.FromAlpha2(fullCountryName.ToUpper()) ??
                          Iso3166.FromAlternativeName(fullCountryName.ToLower()) ??
                          Iso3166.FromAlpha3(fullCountryName.ToUpper()));

            if (result != null) return result.Alpha3;
            Console.WriteLine("nothing found by " + fullCountryName);
            return new Iso3166Country("UNKNOWN", "UNKNOWN", "UNKNOWN", 123456).Alpha3;
        }
    }
}