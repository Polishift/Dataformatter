﻿namespace Dataformatter.Datamodels
{
    public class WorkModel : IModel
    {
        public int Year { get; set; }
        public double MilitairPop { get; set; }
        public double UrbanPop { get; set; }
        public string CountryName { get; set; }
    }
}