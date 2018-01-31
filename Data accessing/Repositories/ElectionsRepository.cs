using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;
using Dataformatter.Dataprocessing.Processors;

namespace Dataformatter.Data_accessing.Repositories
{
    public class ElectionsRepository : AbstractRepository<ElectionEntity>
    {
        //Keeping one static reference instead of recalling the parser means less GC work :)
        private static readonly Dictionary<string, ElectionEntity[]> AllElectionsByCountry =
            JsonReader<ElectionEntity>.ParseJsonToListOfObjects(EntityNames.Election);

        public override ElectionEntity[] GetAll()
        {
            var result = new List<ElectionEntity>();
            foreach (var keyValuePair in AllElectionsByCountry)
                result.AddRange(keyValuePair.Value);
            return result.ToArray();
        }

        public override ElectionEntity[] GetByCountry(string countryCode)
        {
            if(AllElectionsByCountry.ContainsKey(countryCode))
                return AllElectionsByCountry[countryCode];
            else
            {
                Console.WriteLine("WARNING: Country " + countryCode + " has no known elections.");
                return new ElectionEntity[0] { };
            }
        }

        public ElectionEntity[] GetByYear(int year)
        {
            var result = new List<ElectionEntity>();
            foreach (var keyValuePair in AllElectionsByCountry)
                result.AddRange(keyValuePair.Value);
            return result.Where(e => e.Year == year).ToArray();
        }

        public List<string> GetCountryNames()
        {
            return AllElectionsByCountry.Keys.ToList();
        }
    }
}