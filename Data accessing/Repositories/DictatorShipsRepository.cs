using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Parsing;

namespace Dataformatter.Data_accessing.Repositories
{
    public class DictatorShipsRepository : IRepository<DictatorshipEntity>
    {
        private static readonly DictatorshipEntity[] AllDictatorships = 
            JsonReader<DictatorshipEntity>.ParseJsonToListOfObjects("Dictatorships.JSON");

        public DictatorshipEntity[] GetAll()
        {
            return AllDictatorships;
        }

        public DictatorshipEntity[] GetByCountry(string countryCode)
        {
            return AllDictatorships.Where(d => d.CountryCode == countryCode).ToArray();
        }
    }
}