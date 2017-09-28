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
                          Iso3166.FromAlpha3(fullCountryName.ToUpper()) ??
                          Iso3166.FromAlternativeName(fullCountryName.ToLower()));

            if (result == null)
                Console.WriteLine("nothing found by " + fullCountryName);
//            else
//                Console.WriteLine(result);

            return fullCountryName;
        }
    }
}