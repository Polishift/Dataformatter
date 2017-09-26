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
            const string electionsCsvLocation = "Datasources/Political/ElectionResults/election_data.csv";
            IModelFactory<ConstituencyElectionModel> constituencyElectionModelFactory =
                new ConstituencyElectionModelFactory();
            
            var allElectionLinesAsModels = CsvToModel<ConstituencyElectionModel>.ParseAllCsvLinesToModels(
                electionsCsvLocation, constituencyElectionModelFactory);
            
            var processer = new ElectionsProcesser();
            processer.SerializeDataToJson(allElectionLinesAsModels);
            
            const string partyClassificationCsvLocation = "Datasources/Political/PartyClassification/classificationData.csv";
            IModelFactory<PartyClassificationModel> partyClassificationModelFactory =
                new PartyClassificationModelFactory();
            
            var allPartyClassificationLinesAsModels = CsvToModel<PartyClassificationModel>.ParseAllCsvLinesToModels(
                partyClassificationCsvLocation, partyClassificationModelFactory);
            
            var processer2 = new PartyClassificationProcessor();
            processer2.SerializeDataToJson(allPartyClassificationLinesAsModels);
        }
    }
}