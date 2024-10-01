using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.DTO.CarPricingDtos
{
    public class ResultCarPricingDto
    {
        public int CarPricingId { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }

        public string CoverImageUrl { get; set; }

        public double Amount { get; set; }
    }
}
