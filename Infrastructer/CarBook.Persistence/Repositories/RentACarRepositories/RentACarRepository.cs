﻿using CarBook.Aplication.Interfaces.RentACarInterfaces;
using CarBook.Domain;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarBookContext _context;

        public RentACarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filterExpression)
        {
            //return await _context.RentACars.Include(rc=>rc.Location).Where(filterExpression).ToListAsync();
            var values = await _context.RentACars
                .Include(rc=>rc.Location)
                .Include(rc=>rc.Car).ThenInclude(c=> c.CarPricings)
                .Include(rc=>rc.Car).ThenInclude(c=> c.Brand)
                .Where(filterExpression).ToListAsync();

            return values;


        }
    }
}
