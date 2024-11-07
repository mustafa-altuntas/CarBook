using CarBook.Aplication.Interfaces.CarPricingInterfaces;
using CarBook.Aplication.ViewModels;
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
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetAllCarPricingsWithCars()
        {
            return _context.CarPricings.Include(cp => cp.Car).ThenInclude(c => c.Brand).Include(cp => cp.Pricing).Where(x => x.PricingId == 1).ToList();
        }

        public List<CarPricingWithTimePeriodViewModel> GetCarPricingWithTimePeriod()
        {
            var result = _context.CarPricings
                        .Include(cp => cp.Car) // Car navigasyon özelliği
                            .ThenInclude(c => c.Brand) // Marka bilgisine erişim
                        .Include(cp => cp.Pricing) // Pricing bilgisine erişim
                        .GroupBy(cp => new { cp.CarId, cp.Car.Brand.Name, cp.Car.Model }) // Gruba göre gruplama
                        .Select(g => new
                        {
                            CarId = g.Key.CarId,
                            Brand = g.Key.Name,
                            Model = g.Key.Model,
                            Daily = g.Where(cp => cp.PricingId == 1).Max(cp => cp.Amount),
                            Weekly = g.Where(cp => cp.PricingId == 2).Max(cp => cp.Amount),
                            Monthly = g.Where(cp => cp.PricingId == 3).Max(cp => cp.Amount)
                        })
                        .ToList();

            return result.Select(c=> new CarPricingWithTimePeriodViewModel
            {
                CarId=c.CarId,
                Brand=c.Brand,
                Model = c.Model,
                Daily=c.Daily,
                Monthly=c.Monthly,
                Weekly=c.Weekly

            }).ToList();    


        }
    }
}
