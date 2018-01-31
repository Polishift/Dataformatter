using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Repositories;

namespace Dataformatter.Datamodels
{
    public class DictatorshipEntity : IEntity, ICountryRuler
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string PartyClassification { get; set; }

        public RulerType GetRulerType()
        {
            return RulerType.Dictator;
        }

        public static DictatorshipEntity GetEmptyDictatorshipEntity(Iso3166Country associatedCountry)
        {
            return new DictatorshipEntity {CountryCode = associatedCountry.Alpha3, Name = "Unknown", PartyClassification = "Unknown", From = 0000, To = 0000};
        }

        public override string ToString()
        {
            var prettifiedClassification = PrettifiedPartyClassifications.prettifiedPartyClassifications[PartyClassification];

            return Name + ",\nwhich is " + prettifiedClassification + ".\nThey have been in power since " + From + ".";
        }
    }
}