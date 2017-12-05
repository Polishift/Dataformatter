using System.Collections.Generic;
using Dataformatter.Datamodels;
using Dataformatter.Dataprocessing.Entities;
using Dataformatter.Data_accessing.Factories.EntityFactories;
using Dataformatter.Misc;

namespace Dataformatter.Dataprocessing.Processors
{
    public class InterestProcessor : AbstractDataProcessor<InterestModel, InterestEntity>
    {
        public override void SerializeDataToJson(List<InterestModel> rawModels)
        {
            var interestEntities = new List<InterestEntity>();
            var entityFactory = new InterestEntityFactory();
            var interestPerCountryPerYear = new Dictionary<string, Dictionary<int, Tuple<double, int>>>();

            for (var i = 0; i < rawModels.Count; i++)
            {
                var currentModel = rawModels[i];
                if (interestPerCountryPerYear.ContainsKey(currentModel.CountryName))
                {
                    if (interestPerCountryPerYear[currentModel.CountryName].ContainsKey(currentModel.Year))
                    {
                        var oldtuple = interestPerCountryPerYear[currentModel.CountryName][currentModel.Year];
                        interestPerCountryPerYear[currentModel.CountryName][currentModel.Year] =
                            new Tuple<double, int>(
                                (oldtuple.Item1 * oldtuple.Item2 + currentModel.Value) / 1 + oldtuple.Item2,
                                1 + oldtuple.Item2);
                    }
                    else
                    {
                        interestPerCountryPerYear[currentModel.CountryName].Add(currentModel.Year,
                            new Tuple<double, int>(currentModel.Value, 1));
                    }
                }
                else
                {
                    interestPerCountryPerYear.Add(currentModel.CountryName, new Dictionary<int, Tuple<double, int>>
                    {
                        {currentModel.Year, new Tuple<double, int>(currentModel.Value, 1)}
                    });
                }
            }

            foreach (var country in interestPerCountryPerYear)
            {
                foreach (var year in country.Value)
                {
                    interestEntities.Add(entityFactory.Create(new InterestModel
                    {
                        CountryName = country.Key,
                        Value = year.Value.Item1,
                        Year = year.Key
                    }));
                }
            }

            WriteEntitiesToJson(EntityNames.Interest, interestEntities);
        }
    }
}