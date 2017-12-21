using System;
using System.Collections.Generic;
using System.IO;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Filters
{
    public class EuropeFilter : IFilter
    {
        private readonly HashSet<string> _europeanSet = new HashSet<string>
        {
            "ALB",
            "AND",
            "AUT",
            "BLR",
            "BEL",
            "BIH",
            "BGR",
            "HRV",
            "CYP",
            "CZE",
            "DNK",
            "EST",
            "FRO",
            "FIN",
            "FRA",
            "DEU",
            "GIB",
            "GRC",
            "HUN",
            "ISL",
            "IRL",
            "IMN",
            "ITA",
            "XKX",
            "LVA",
            "LIE",
            "LTU",
            "LUX",
            "MKD",
            "MLT",
            "MDA",
            "MCO",
            "MNE",
            "NLD",
            "NOR",
            "POL",
            "PRT",
            "ROU",
            "RUS",
            "SMR",
            "SRB",
            "SVK",
            "SVN",
            "ESP",
            "SWE",
            "CHE",
            "UKR",
            "GBR",
            "VAT",
            "RSB"
        };

        public void Filter()
        {
            var rootFolderPath = Paths.ProcessedDataFolder;
            foreach (var entity in Enum.GetNames(typeof(EntityNames)))
            {
                Console.WriteLine("Deleting files of: " + entity);
                var filesToDelete = @"*" + entity + "*.json";
                var fileList = Directory.GetFiles(rootFolderPath, filesToDelete);
                foreach (var file in fileList)
                {
                    var countryName = file.Substring(file.IndexOf('_') + 1, 3);
                    if (_europeanSet.Contains(countryName)) continue;
                    Console.WriteLine(file + " will be deleted");
                    File.Delete(file);
                }
            }
        }
    }
}