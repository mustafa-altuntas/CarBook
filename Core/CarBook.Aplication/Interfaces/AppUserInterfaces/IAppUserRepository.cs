using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Interfaces.AppUserInterfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filterExpression);
    }
}
