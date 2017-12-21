using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Datamodels
{
    public class DictatorshipEntity : IEntity, ICountryRuler
    {
        public string CountryCode { get; set; }
		public string Name { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string PartyClassification { get; set; }

		public override string ToString()
        {
            return Name + ", which is '" + PartyClassification + "' " +  
                   " has ruled since " + From;
        }
    }
} 