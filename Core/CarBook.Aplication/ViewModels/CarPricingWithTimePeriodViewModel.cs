using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.ViewModels
{
    public class CarPricingWithTimePeriodViewModel
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string CoverImageUrl { get; set; }
        public string Model { get; set; }
        public double Daily { get; set; }
        public double Weekly { get; set; }
        public double Monthly { get; set; }


    }
}
