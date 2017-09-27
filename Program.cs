using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.CsvParsing;
using Dataformatter.Dataprocessing.Processors;
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
            
            var processor = new ElectionsProcessor();
            processor.SerializeDataToJson(allElectionLinesAsModels);
            
            const string partyClassificationCsvLocation = "Datasources/Political/PartyClassification/classificationData.csv";
            IModelFactory<PartyClassificationModel> partyClassificationModelFactory =
                new PartyClassificationModelFactory();
            
            var allPartyClassificationLinesAsModels = CsvToModel<PartyClassificationModel>.ParseAllCsvLinesToModels(
                partyClassificationCsvLocation, partyClassificationModelFactory);
            
            var processor2 = new PartyClassificationProcessor();
            processor2.SerializeDataToJson(allPartyClassificationLinesAsModels);
            
            const string turnoutCsvLocation = "Datasources/Political/Turnout/turnout_data.csv";
            IModelFactory<TurnoutModel> turnoutModelFactory =
                new TurnoutModelFactory();
            
            var allTurnoutModels = CsvToModel<TurnoutModel>.ParseAllCsvLinesToModels(
                turnoutCsvLocation, turnoutModelFactory);
            
            var processor3 = new TurnoutProcessor();
            processor3.SerializeDataToJson(allTurnoutModels);
            
            
        }
    }
}