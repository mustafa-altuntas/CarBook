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
        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filterExpression)
        {
            return await _context.RentACars.Where(filterExpression).ToListAsync();
        }
    }
}
