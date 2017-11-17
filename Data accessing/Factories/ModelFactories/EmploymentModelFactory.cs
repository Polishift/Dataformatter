using System;
using System.Collections.Generic;
using System.Globalization;
using Dataformatter.Datamodels;

namespace Dataformatter.Data_accessing.Factories.ModelFactories
{
    public class EmploymentModelFactory : ICsvModelFactory<EmploymentModel>
    {
        private const int CountryNameColumnIndex = 0;

        private const int YearColumnIndex = 5;

        private const int ValueColumnIndex = 6;


        public EmploymentModel Create(List<string> csvDataRow)
        {
            return new EmploymentModel
            {
                CountryName = csvDataRow[CountryNameColumnIndex],
                Year = int.Parse(csvDataRow[YearColumnIndex]),
                EmployedPercentage = double.Parse(csvDataRow[ValueColumnIndex]),
            };

        }

        private string ReplaceCommasInThousands(string input)
        {
            if (input.Equals(""))
                return "-1";

            var output = input.Replace(",", "");
            return output;
        }
    }
}