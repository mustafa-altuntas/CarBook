using CarBook.Aplication.Interfaces.CarPricingInterfaces;
using CarBook.Domain;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository:ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetAllCarPricingsWithCars()
        {
            return _context.CarPricings.Include(cp => cp.Car).ThenInclude(c => c.Brand).Include(cp => cp.Pricing).Where(x=>x.PricingId==1).ToList();
        }

    }
}
