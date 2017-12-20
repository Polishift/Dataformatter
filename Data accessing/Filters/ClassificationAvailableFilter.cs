using System;
using System.Collections.Generic;
using System.IO;

namespace Dataformatter.Data_accessing.Filters
{
    public class ClassificationAvailableFilter : IFilter
    {
        public void Filter()
        {
            var rootFolderPath = Paths.ProcessedDataFolder;
            const string filesToDelete = @"*Election*.json";
            var fileList = Directory.GetFiles(rootFolderPath, filesToDelete);
            foreach (var file in fileList)
            {
                var x = file.Substring(file.IndexOf('_') + 1, 3);
                if (_classificationAvailableSet.Contains(x)) continue;
                Console.WriteLine(file + " will be deleted");
                File.Delete(file);
            }
        }
        
        //belarus is a dictatorship so its exempt
        //we'll do russia by hand, its only free since 1991 :)
        private readonly HashSet<string> _classificationAvailableSet = new HashSet<string>
        {
            "AUT",
            "BLR",
            "BEL",
            "BGR",
            "HRV",
            "CYP",
            "CZE",
            "DNK",
            "EST",
            "FRA",
            "DEU",
            "GRC",
            "FIN",
            "HUN",
            "IRL",
            "ITA",
            "LVA",
            "LTU",
            "LUX",
            "MLT",
            "NLD",
            "POL",
            "PRT",
            "ROU",
            "RUS",
            "SVK",
            "SVN",
            "ESP",
            "SWE",
            "GBR",
        };
        
        
    }
}