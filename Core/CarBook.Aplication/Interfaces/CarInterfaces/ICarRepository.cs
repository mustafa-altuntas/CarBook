using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        public List<Car> GetAllCarWhithBrand();

    }
}
