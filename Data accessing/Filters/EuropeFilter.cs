using System;
using System.Collections.Generic;
using System.IO;

namespace Dataformatter.Data_accessing.Filters
{
    public class EuropeFilter : IFilter
    {
        public void Filter()
        {
            var rootFolderPath = Paths.ProcessedDataFolder;
            const string filesToDelete = @"*Election*.json";
            var fileList = Directory.GetFiles(rootFolderPath, filesToDelete);
            foreach (var file in fileList)
            {
                var x = file.Substring(file.IndexOf('_') + 1, 3);
                if (_europeanSet.Contains(x)) continue;
                Console.WriteLine(file + " will be deleted");
                File.Delete(file);
            }
        }

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
    }
}