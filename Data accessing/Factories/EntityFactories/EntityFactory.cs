using System;
using Dataformatter.Data_accessing.Repositories;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public abstract class EntityFactory
    {
        protected string CreateCountryCode(string fullCountryName)
        {
            var result = Iso3166Repository.FromName(fullCountryName.ToLower()) ??
                         (Iso3166Repository.FromAlpha2(fullCountryName.ToUpper()) ??
                          Iso3166Repository.FromAlpha3(fullCountryName.ToUpper()) ??
                          Iso3166Repository.FromAlternativeName(fullCountryName.ToLower()));

            if (result == null)
                Console.WriteLine("nothing found by " + fullCountryName);
            //else
               //Console.WriteLine(result);

            return fullCountryName;
        }
    }
}