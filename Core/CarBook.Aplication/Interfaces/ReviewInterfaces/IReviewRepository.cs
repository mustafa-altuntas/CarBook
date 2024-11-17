using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Interfaces.ReviewInterfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetReviewByCarId(int carId);
    }
}
