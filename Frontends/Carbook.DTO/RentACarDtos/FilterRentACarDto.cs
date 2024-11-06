using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.DTO.RentACarDtos
{
    public class FilterRentACarDto
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Amount { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
