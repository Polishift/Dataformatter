using System;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class DefaultPartyClassificationEntityFactory : EntityFactory
    {
        public PartyClassificationEntity Create(PartyClassificationModel rawModel)
        {
            return new PartyClassificationEntity
            {
                Name = rawModel.Name,
                CountryCode = CreateCountryCode(rawModel.CountryName),
                Classification = rawModel.Classification
            };
        }

        
    }
}