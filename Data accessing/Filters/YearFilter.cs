using System.IO;
using System.Linq;
using Dataformatter.Data_accessing.Repositories;
using Newtonsoft.Json;

namespace Dataformatter.Data_accessing.Filters
{
    public class YearFilter : IFilter
    {
        private readonly string _processedPath = Paths.ProcessedDataFolder;

        private const int Year = 1945;

        public void Filter()
        {
            var electionsRepo = new ElectionsRepository();

            var countries = electionsRepo.GetCountryNames();

            foreach (var electionCountry in countries)
            {
                var countryElections = electionsRepo.GetByCountry(electionCountry).ToList();

                countryElections.RemoveAll(entity => entity.Year < Year);

                //remove the file if there is no data above the YEAR
                if (countryElections.Count <= 0)
                {
                    File.Delete(_processedPath + "Election_" + countryElections[0].CountryCode +
                                ".json");
                    continue;
                }
                
                using (var file =
                    File.CreateText(_processedPath + "Election_" + countryElections[0].CountryCode +
                                    ".json"))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(file, countryElections);
                }
            }
        }
    }
}