using System.Collections.Generic;
using System.Linq;
using Dataformatter.Dataprocessing.Parsing;

namespace Dataformatter.Data_accessing.Repositories
{
    public static class Iso3166Repository
    {
        private static Iso3166Country[] _collection;


        /*
        * Enormous dict to convert the country codes from the classification dataset to normal Alpha3 codes.
        */

        private static readonly Dictionary<string, string> DatasetIdsToAlpha3 = new Dictionary<string, string>
        {
            {"AUS", "AUT"},
            {"BE", "BEL"},
            {"BUL", "BGR"},
            {"CRO", "HRV"},
            {"CYP", "CYP"},
            {"CZ", "CZE"},
            {"DK", "DNK"},
            {"EST", "EST"},
            {"FR", "FRA"},
            {"GE", "DEU"},
            {"GR", "GRC"},
            {"HUN", "HUN"},
            {"IRL", "IRL"},
            {"IT", "ITA"},
            {"LAT", "LVA"},
            {"LITH", "LTU"},
            {"LUX", "LUX"},
            {"MAL", "MLT"},
            {"NL", "NLD"},
            {"POL", "POL"},
            {"POR", "PRT"},
            {"ROM", "ROU"},
            {"SLO", "SVK"},
            {"SLE", "SVN"},
            {"ESP", "ESP"},
            {"SV", "SWE"},
            {"UK", "GBR"}
        };

        static Iso3166Repository()
        {
            if (Paths.RawDataFolder != null && Paths.ProcessedDataFolder != null)
                InitializeCollection();
        }

        private static void InitializeCollection()
        {
            _collection = JsonReader<Iso3166Country>.ParseJsonToListOfObjects("countries.json");
        }

        public static Iso3166Country[] GetCollection()
        {
            return _collection;
        }

        public static string GetCountryName(this string alpha3)
        {
            return _collection.FirstOrDefault(
                p => p.Alpha3 == alpha3)
                ?.Name;
        }


        public static Iso3166Country FromName(string name)
        {
            return _collection.FirstOrDefault(
                p => p.Name == name);
        }

        public static Iso3166Country FromClassificationCodes(string classificationDatasetCode)
        {
            classificationDatasetCode = classificationDatasetCode.ToUpper();
            var convertedAlpha3 = "";

            //converted classificationcode to alpha 3, then return from alpha 3
            if (DatasetIdsToAlpha3.ContainsKey(classificationDatasetCode))
                convertedAlpha3 = DatasetIdsToAlpha3[classificationDatasetCode];

            return FromAlpha3(convertedAlpha3);
        }

        public static Iso3166Country FromAlpha3(string alpha3)
        {
            return _collection.FirstOrDefault(
                p => p.Alpha3 == alpha3);
        }

        public static Iso3166Country FromAlpha2(string alpha2)
        {
            return _collection.FirstOrDefault(
                p => p.Alpha2 == alpha2);
        }

        public static Iso3166Country FromAlternativeName(string alternative)
        {
            for (var index = 0; index < _collection.Length; ++index)
            {
                var iso3166Country =
                    _collection.ElementAt(index);
                if (iso3166Country.AlternativeNames != null && iso3166Country.AlternativeNames.Contains(alternative))
                    return iso3166Country;
            }
            return null;
        }
    }
}