using System;
using Dataformatter.Dataprocessing;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class EntityFactory
    {
        protected static string CreateCountryCode(string fullCountryName)
        {
            var result = ISO3166.FromName(fullCountryName.ToLower()) ??
                         (ISO3166.FromAlpha2(fullCountryName.ToUpper()) ??
                          ISO3166.FromAlpha3(fullCountryName.ToUpper()));

            if (result == null)
                Console.WriteLine("nothing found by " + fullCountryName);
            else
                Console.WriteLine(result);

            return fullCountryName;
        }
    }
}
