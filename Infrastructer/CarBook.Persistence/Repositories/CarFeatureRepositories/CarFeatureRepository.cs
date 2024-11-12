using CarBook.Aplication.Interfaces.CarFeatureInterfaces;
using CarBook.Domain;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarFeature> GetCarFeatureByCarId(int carId)
        {
            var values = _context.CarFeatures.Where(x=>x.CarId == carId).ToList();
            return values;
        }
    }
}
