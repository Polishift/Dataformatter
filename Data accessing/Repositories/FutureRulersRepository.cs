using System;
using System.Linq;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Dataprocessing.Parsing;

namespace Dataformatter.Data_accessing.Repositories
{
    public class FutureRulersRepository : AbstractRepository<FutureRulerEntity>
    {
        private static readonly FutureRulerEntity[] AllFutureRulers = JsonReader<FutureRulerEntity>.ParseJsonToListOfObjects("FutureRulers.JSON");

        public override FutureRulerEntity[] GetAll()
        {
            return AllFutureRulers;
        }

        public override FutureRulerEntity[] GetByCountry(string countryCode)
        {
            //Todo: Return unknown if dictatorship forever
            var futureRulerForThisCountry = AllFutureRulers.Where(d => d.CountryCode == countryCode);
            
            if(futureRulerForThisCountry.Any())
                return AllFutureRulers.Where(d => d.CountryCode == countryCode).ToArray();
            else
            {
                //This country has been a dictatorship forever, so there was no elected party ruling after 2012.
                //(The predictions only take elections into account)
                return new FutureRulerEntity[] {new FutureRulerEntity() {CountryCode = countryCode, FutureRulingPartyClassification = "unknown"}};
            }
        }
    }
}