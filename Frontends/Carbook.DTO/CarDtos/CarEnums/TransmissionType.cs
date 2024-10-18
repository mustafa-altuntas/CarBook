using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.DTO.CarDtos.CarEnums
{
    public enum TransmissionType
    {
        Manuel,            // Geleneksel manuel vites
        Otomatik,          // Geleneksel otomatik vites
        YarıOtomatik,      // Manuel ve otomatik karışımı
        CVT,               // Sürekli değişken oranlı vites (Continuously Variable Transmission)
        ÇiftKavrama,       // Çift kavramalı vites (Dual Clutch Transmission)
        Elektrikli,        // Elektrikli araçlarda kullanılan vites
        DişliOtomatik      // Dişli tabanlı otomatik vites
    }
}
