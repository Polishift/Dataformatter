﻿namespace Dataformatter.Dataprocessing.Entities
{
    public class InterestEntity : IEntity
    {
        public string CountryCode { get; set; }
        public int Year { get; set; }
        public double Value{ get; set; }
    }
}