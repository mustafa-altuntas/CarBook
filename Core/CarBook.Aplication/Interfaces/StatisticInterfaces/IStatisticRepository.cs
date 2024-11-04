using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Interfaces.StatisticInterfaces
{
    public interface IStatisticRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetAuthorCount();
        int GetBlogCount();
        int GetBrandCount();

        /// <returns> Günlük ortalama satış tutarını döner. </returns>
        double GetAvgRentPriceForDaily();       
        /// <returns> Haftalık ortalama satış tutarını döner. </returns>
        double GetAvgRentPriceForWeekly();      
        /// <returns> Aylık ortalama satış tutarını döner. </returns>
        double GetAvgRentPriceForMonthly();     
        /// <returns> Otomatik fitesli araç sayısını döner. </returns>
        int GetCarCountByTransmissionIsAuto();
        /// <returns> En fazla araca sahip markayı döner. </returns>
        string GetBrandNameByMaxCar();
        /// <returns> En fazla yorum alan blog başlığını döner. </returns>
        string GetBlogTitleByMaxBlogComment();
        /// <returns> 1000 KM den düşük araçların sayısını döner. </returns>
        int GetCarCountByKmSmallerThen1000();
        /// <returns> Benzinli veya Dizel araç sayısını döner. </returns>
        int GetCarCountByFuelGasolineOrDiesel();
        /// <returns> Elektirikli araç sayısını döner. </returns>
        int GetCarCountByFuelElecttic();
        /// <returns> Günlük kiralama bedeli en pahalı aracın marka ve modelini döner </returns>
        string GetCarBrandAndModelByRentPriceDailyMax();
        /// <returns> Günlük kiralama bedeli en ucuz aracın marka ve modelini döner </returns>
        string GetCarBrandAndModelByRentPriceDailyMin();
        /// <returns>  </returns>



    }
}
