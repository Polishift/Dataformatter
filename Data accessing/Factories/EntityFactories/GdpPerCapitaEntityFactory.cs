using System;
using System.Collections.Generic;
using System.Linq;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class GdpTotalEntityFactory : EntityFactory<GdpTotalModel, GdpTotalEntity>
    {
        public override GdpTotalEntity Create(GdpTotalModel rawTotalModel)
        {
            //this one is not used.
            throw new NotImplementedException();
        }

        public IEnumerable<GdpTotalEntity> Convert(GdpTotalModel rawTotalModel)
        {
            var results = rawTotalModel.ValueByYear.Select(values => new GdpTotalEntity
            {
                CountryCode = CreateCountryCode(
                    rawTotalModel.CountryName.IndexOf(' ') > 0
                        ? rawTotalModel.CountryName.Substring(0, rawTotalModel.CountryName.IndexOf(' '))
                        : rawTotalModel.CountryName
                ),
                Year = values.Key,
                Total = (int) (values.Value * 1000)
            });

            return results;
        }
    }
}