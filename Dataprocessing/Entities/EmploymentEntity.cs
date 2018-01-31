﻿namespace Dataformatter.Dataprocessing.Entities
{
    public class EmploymentEntity : IEntity
    {
        public int Year { get; set; }
        public double EmployedPercentage { get; set; }
        public string CountryCode { get; set; }
    }
}