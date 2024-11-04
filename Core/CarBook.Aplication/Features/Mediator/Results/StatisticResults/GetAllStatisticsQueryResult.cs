using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Results.StatisticResults
{
    public class GetAllStatisticsQueryResult
    {
        public int AuthorCount { get; set; }
        public double AvgRentPriceForDaily { get; set; }
        public double AvgRentPriceForMonthly { get; set; }
        public double AvgRentPriceForWeekly { get; set; }
        public int BlogCount { get; set; }
        public string BlogTitleByMaxBlogComment { get; set; }
        public int BrandCount { get; set; }
        public string BrandNameByMaxCar { get; set; }
        public string CarBrandAndModelByRentPriceDailyMax { get; set; }
        public string CarBrandAndModelByRentPriceDailyMin { get; set; }
        public int CarCountByFuelElecttic { get; set; }
        public int CarCountByFuelGasolineOrDiesel { get; set; }
        public int CarCountByKmSmallerThen1000 { get; set; }
        public int CarCountByTransmissionIsAuto { get; set; }
        public int CarCount { get; set; }
        public int LocationCount { get; set; }





    }
}
