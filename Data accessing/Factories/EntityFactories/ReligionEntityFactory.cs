using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;

namespace Dataformatter.Data_accessing.Factories.EntityFactories
{
    public class ReligionEntityFactory : EntityFactory<ReligionModel,
        ReligionEntity>
    {
        public override ReligionEntity Create(ReligionModel rawModel)
        {
            return new ReligionEntity
            {
                CountryCode = CreateCountryCode(rawModel.CountryName),
                Year = rawModel.Year,
                ChrstProt = rawModel.ChrstProt,
                ChrstCat = rawModel.ChrstCat,
                ChrstOther = rawModel.ChrstTotal - (rawModel.ChrstProt + rawModel.ChrstCat),
                ChrstTotal = rawModel.ChrstTotal,

                JudTotal = rawModel.JudTotal,

                IslmTotal = rawModel.IslmTotal,

                BudTotal = rawModel.BudTotal,

                NonTotal = rawModel.NonTotal,

                Other = rawModel.SumTotal - (rawModel.ChrstTotal +
                                             rawModel.JudTotal +
                                             rawModel.IslmTotal +
                                             rawModel.BudTotal +
                                             rawModel.NonTotal),

                SumTotal = rawModel.SumTotal
            };
        }
    }
}