using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        public List<CarPricing> GetAllCarWhitPricings();

    }
}
