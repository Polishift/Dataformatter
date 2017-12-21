using System;
using System.Collections.Generic;
using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class GdpPerCapitaEntityFactory : EntityFactory<GdpPerCapitaModel, GdpPerCapitaEntity>
    {
        public override GdpPerCapitaEntity Create(GdpPerCapitaModel rawTotalModel)
        {
            //this one is not used.
            throw new NotImplementedException();
        }

        public IEnumerable<GdpPerCapitaEntity> Convert(GdpPerCapitaModel rawModel)
        {
            var results = rawModel.ValueByYear.Select(values => new GdpPerCapitaEntity
            {
                CountryCode = CreateCountryCode(
                    rawModel.CountryName.IndexOf(' ') > 0
                        ? rawModel.CountryName.Substring(0, rawModel.CountryName.IndexOf(' '))
                        : rawModel.CountryName
                ),
                Year = values.Key,
                Total = (int) (values.Value * 1000)
            });

            return results;
        }
    }
}