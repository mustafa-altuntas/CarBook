using CarBook.Aplication.Interfaces.ReviewInterfaces;
using CarBook.Domain;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarBookContext _context;

        public ReviewRepository(CarBookContext context)
        {
            _context = context;
        }

        public IEnumerable<Review> GetReviewByCarId(int carId)
        {
            var values = _context.Reviews.Where(r=>r.CarId == carId).ToList();
            return values;
        }
    }
}
