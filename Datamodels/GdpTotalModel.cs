﻿using System.Collections.Generic;
using Dataformatter.Misc;

namespace Dataformatter.Datamodels
{
    public class GdpTotalModel : IModel
    {
        public string CountryName { get; set; }
        public Dictionary<int, double> ValueByYear { get; set; }
    }
}