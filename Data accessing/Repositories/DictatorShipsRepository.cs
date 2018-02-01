using System;
using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Parsing;

namespace Dataformatter.Data_accessing.Repositories
{
    public class DictatorShipsRepository : AbstractRepository<DictatorshipEntity>
    {
        private static readonly DictatorshipEntity[] AllDictatorships = 
            JsonReader<DictatorshipEntity>.ParseJsonToListOfObjects("Dictatorships.JSON");

        public override DictatorshipEntity[] GetAll()
        {
            return AllDictatorships;
        }

        public override DictatorshipEntity[] GetByCountry(string countryCode)
        {
            if(AllDictatorships.Any(d => d.CountryCode == countryCode))
                return AllDictatorships.Where(d => d.CountryCode == countryCode).ToArray();
            else
            {
                Console.WriteLine("WARNING: Country " + countryCode + " has no known dictatorships.");
                return new DictatorshipEntity[0] { };
            }
        }
    }
}