using System;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.CsvParsing;
using Dataformatter.Dataprocessing.Processers;
using Dataformatter.Data_accessing.Factories;

namespace Dataformatter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var electionsCsvLocation = "Datasources//election_data.csv";
            IModelFactory<ConstituencyElectionModel> constituencyElectionModelFactory = new ConstituencyElectionModelFactory();
            var allElectionLinesAsModels = CsvToModel<ConstituencyElectionModel>.ParseAllCsvLinesToModels(electionsCsvLocation,
                constituencyElectionModelFactory);
            ElectionsProcesser processer = new ElectionsProcesser();
            processer.SerializeDataToJSON(allElectionLinesAsModels);
        }
    }
}
