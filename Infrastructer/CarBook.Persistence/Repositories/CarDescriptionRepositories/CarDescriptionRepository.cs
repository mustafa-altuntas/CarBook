﻿using CarBook.Aplication.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarBookContext _context;

        public CarDescriptionRepository(CarBookContext context)
        {
            _context = context;
        }

        public CarDescription GetCarDescription(int carId)
        {
            var value = _context.CarDescriptions.Where(x=>x.CarId == carId).FirstOrDefault();
            return value;
        }
    }
}
