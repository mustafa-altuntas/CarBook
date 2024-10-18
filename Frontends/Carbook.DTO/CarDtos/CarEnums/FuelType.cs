using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.DTO.CarDtos.CarEnums
{
    public enum FuelType
    {
        Benzin,           // Benzinle çalışan araçlar
        Dizel,            // Dizel yakıt kullanan araçlar
        Elektrik,         // Elektrikli araçlar
        Hibrit,           // Hem elektrik hem de benzinli/dizel kombinasyonu
        LPG,              // Sıvılaştırılmış petrol gazı kullanan araçlar
        CNG,              // Sıkıştırılmış doğal gaz kullanan araçlar
        Hidrojen,         // Hidrojen yakıt hücreli araçlar
        Biyodizel         // Biyodizel yakıt kullanan araçlar
    }
}
