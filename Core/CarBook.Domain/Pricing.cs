using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain
{
    public class Pricing
    {
        public int PricingId { get; set; }
        public string Name { get; set; } // Yıllık - Aylık - Haftalık - Günlük
        public List<CarPricing> CarPricings { get; set; }

    }
}
