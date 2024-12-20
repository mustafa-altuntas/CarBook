﻿using CarBook.Aplication.Interfaces.CarFeatureInterfaces;
using CarBook.Domain;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
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

        public void ChangeCarFeatureAvailableToFalse(int id)
        {
            var value = _context.CarFeatures.Where(x=>x.CarFeatureId == id).FirstOrDefault();
            value.Available = false;
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int id)
        {
            var value = _context.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
            value.Available = true;
            _context.SaveChanges();
        }

        public void CreateCarFeatureByCar(CarFeature carFeature)
        {
            _context.CarFeatures.Add(carFeature);
            _context.SaveChanges();
        }

        public List<CarFeature> GetCarFeatureByCarId(int carId)
        {
            var values = _context.CarFeatures
                .Include(x=>x.Feature)
                .Where(x=>x.CarId == carId).ToList();
            return values;
        }
    }
}
