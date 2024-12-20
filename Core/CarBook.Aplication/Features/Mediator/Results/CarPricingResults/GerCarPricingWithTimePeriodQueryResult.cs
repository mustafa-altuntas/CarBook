﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Results.CarPricingResults
{
    public class GerCarPricingWithTimePeriodQueryResult
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public string CoverImageUrl { get; set; }
        public double DailyAmount { get; set; }
        public double WeeklyAmount { get; set; }
        public double MonthlAmount { get; set; }
    }
}
