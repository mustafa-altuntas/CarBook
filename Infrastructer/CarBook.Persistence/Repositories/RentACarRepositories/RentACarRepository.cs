﻿using CarBook.Aplication.Interfaces.RentACarInterfaces;
using CarBook.Domain;
using CarBook.Persistence.Context;
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

        public Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filterExpression)
        {
            _context.
        }
    }
}