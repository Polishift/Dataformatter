using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.CsvParsing;
using Dataformatter.Dataprocessing.Processors;
using Dataformatter.Data_accessing.Factories;
using Dataformatter.Data_accessing.Factories.ModelFactories;
using Dataformatter.Data_accessing.Repositories;

namespace Dataformatter
{
    internal static class Program
    {
        private static void Main()
        {
            const string electionsCsvLocation = "Datasources/Political/ElectionResults/election_data.csv";
            const string partyClassificationCsvLocation =
                "Datasources/Political/PartyClassification/classificationData.csv";
            const string turnoutCsvLocation = "Datasources/Political/Turnout/turnout_data.csv";


            IModelFactory<ConstituencyElectionModel> modelFactory =
                new ConstituencyElectionModelFactory();

            var allItemsAsModels = CsvToModel<ConstituencyElectionModel>.ParseAllCsvLinesToModels(
                electionsCsvLocation, modelFactory);

            var processor = new ElectionsProcessor();
            processor.SerializeDataToJson(allItemsAsModels);


            var repository = new ElectionsRepository();
            foreach (var electionEntity in repository.GetAll())
            {
                Console.WriteLine(electionEntity);
            }
        }
    }
}