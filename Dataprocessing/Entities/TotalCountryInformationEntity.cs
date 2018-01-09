using System.Collections.Generic;

namespace Dataformatter.Dataprocessing.Entities
{
    public class TotalCountryInformationEntity : IEntity
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public List<CountryInformationEntity> InformationEntities;
    }
}