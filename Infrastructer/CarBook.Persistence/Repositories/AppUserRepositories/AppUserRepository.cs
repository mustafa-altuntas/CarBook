﻿using CarBook.Aplication.Interfaces.AppUserInterfaces;
using CarBook.Domain;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository:IAppUserRepository
    {
        private readonly CarBookContext _context;

        public AppUserRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filterExpression)
        {
            var values = await _context.AppUsers
                .Include(x => x.AppRole)
                .Where(filterExpression).FirstOrDefaultAsync();

            return values;


        }
    }
}
