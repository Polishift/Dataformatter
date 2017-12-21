using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dataformatter.Data_accessing.Repositories
{
    /// <summary>
    ///     Representation of an ISO3166-1 Country
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

        public string Name { get; }

        public string Alpha2 { get; }

        public string Alpha3 { get; }

        public List<string> AlternativeNames { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}