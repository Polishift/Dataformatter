using System.Collections.Generic;

namespace Dataformatter.Dataprocessing.Entities
{
    public class ClassificationEntity : IEntity
    {
        public string CountryCode { get; set; }
        public string PartyName { get; set; }
        public string Abbreviation { get; set; }
        public string Classification { get; set; }
    }
}