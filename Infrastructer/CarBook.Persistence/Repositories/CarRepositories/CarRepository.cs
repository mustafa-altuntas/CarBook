﻿using CarBook.Aplication.Interfaces.CarInterfaces;
using CarBook.Domain;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Car> GetAllCarWhithBrand()
        {
            return _context.Cars.Include(c=> c.Brand).ToList();
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

        public List<Car> GetLast5CarsWhithBrands()
        {
            var values = _context.Cars.Include(c=>c.Brand).OrderByDescending(x=>x.CarId).Take(5).ToList();
            return values;
        }
    }
}
