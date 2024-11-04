using CarBook.Aplication.Interfaces.StatisticInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {

            /*
                select top 1 b.Title, c.BlogID,COUNT(*) as CommentCount from Comments c
                join Blogs b on c.BlogID=b.BlogID
                group by c.BlogID,b.Title
                order by COUNT(*) desc
            */

            var value = _context.Comments
                .Include(c => c.Blog)
                .GroupBy(c => new { c.BlogID, c.Blog.Title })
                .Select(group => new
                {
                    Result = group.Key.Title + " | BlogID:" + group.Key.BlogID,
                    Count = group.Count()
                })
                .OrderByDescending(x => x.Count)
                .FirstOrDefault();
            return value!.Result;

        }

        public int GetAuthorCount()
        {
            return _context.Authors.Count();
        }

        public double GetAvgRentPriceForDaily()
        {
            //var value = _context.CarPricings.Where(cp=>cp.PricingId==1).Average(cp=>cp.Amount);
            var value = _context.CarPricings
                .Include(cp => cp.Pricing)
                .Where(cp => cp.Pricing.Name == "Günlük")
                .Average(cp => cp.Amount);
            return value;
        }

        public double GetAvgRentPriceForMonthly()
        {

            var value = _context.CarPricings
                .Include(cp => cp.Pricing)
                .Where(cp => cp.Pricing.Name == "Aylık")
                .Average(cp => cp.Amount);
            return value;
        }

        public double GetAvgRentPriceForWeekly()
        {

            var value = _context.CarPricings
                .Include(cp => cp.Pricing)
                .Where(cp => cp.Pricing.Name == "Haftalık")
                .Average(cp => cp.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            return _context.Blogs.Count();
        }

        public int GetBrandCount()
        {
            return (_context.Brands.Count());
        }

        public string GetBrandNameByMaxCar()
        {
            /*
                select top 1 b.Name from Cars c
                join Brands b on c.BrandId=b.BrandId
                Group By  b.Name
                order by COUNT(*) desc
            */

            return _context.Cars
                .Join(_context.Brands,
                car => car.BrandId,
                brand => brand.BrandId,
                (car, brand) => new { car, brand.Name })
                .GroupBy(x => x.Name)
                .OrderByDescending(grup => grup.Count())
                .Select(grup => grup.Key)
                .FirstOrDefault()!;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            /*
                select top 1  b.Name, c.Model, Max(cp.Amount) as Tutar from CarPricings cp
                join Cars c on cp.CarId=c.CarId
                join Brands b on c.BrandId=b.BrandId
                where PricingId = (select PricingId from Pricings where Name='Günlük')
                group by b.Name, c.Model
                order by Max(Amount) desc
             */

            var value = _context.CarPricings
                .Include(cp => cp.Car)
                .ThenInclude(c => c.Brand)
                .Include(cp => cp.Pricing)
                .Where(cp => cp.Pricing.Name == "Günlük")
                .GroupBy(cp => new { cp.Car.Brand.Name, cp.Car.Model })
                .Select(group => new
                {
                    Result = group.Key.Name + " " + group.Key.Model + ": " + group.Max(cp => cp.Amount) + "₺",
                    Tutar = group.Max(cp => cp.Amount)
                })
                .OrderByDescending(x => x.Tutar)
                .FirstOrDefault();
            return value!.Result;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            /*
               select top 1  b.Name, c.Model, Max(cp.Amount) as Tutar from CarPricings cp
               join Cars c on cp.CarId=c.CarId
               join Brands b on c.BrandId=b.BrandId
               where PricingId = (select PricingId from Pricings where Name='Günlük')
               group by b.Name, c.Model
               order by Max(Amount) desc
            */

            var value = _context.CarPricings
                .Include(cp => cp.Car)
                .ThenInclude(c => c.Brand)
                .Include(cp => cp.Pricing)
                .Where(cp => cp.Pricing.Name == "Günlük")
                .GroupBy(cp => new { cp.Car.Brand.Name, cp.Car.Model })
                .Select(group => new
                {
                    Result = group.Key.Name + " " + group.Key.Model + ": " + group.Min(cp => cp.Amount) + "₺",
                    Tutar = group.Min(cp => cp.Amount)
                })
                .OrderBy(x => x.Tutar)
                .FirstOrDefault();
            return value!.Result;
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

        public int GetCarCountByFuelElecttic()
        {
            return _context.Cars.Where(c => c.Fuel == "Elektirik").Count();
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            return _context.Cars.Where(c => c.Fuel == "Benzin" || c.Fuel == "Dizel").Count();
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            return _context.Cars.Where(car => car.Km <= 1000).Count();
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            return _context.Cars.Where(c => c.Transmission == "Otomatik").Count();
        }

        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }
    }
}
