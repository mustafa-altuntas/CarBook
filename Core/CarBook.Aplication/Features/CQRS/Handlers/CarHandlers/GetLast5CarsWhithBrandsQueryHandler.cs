using CarBook.Aplication.Features.CQRS.Results.CarResults;
using CarBook.Aplication.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWhithBrandsQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetLast5CarsWhithBrandsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<GetLast5CarsWhithBrandsQueryResult> Handler()
        {
            return _carRepository.GetLast5CarsWhithBrands().Select(c => new GetLast5CarsWhithBrandsQueryResult
            {
                CarId = c.CarId,
                BrandId = c.BrandId,
                BrandName = c.Brand.Name,
                CoverImageUrl = c.CoverImageUrl,
                Fuel = c.Fuel,
                Km = c.Km,
                Luggage = c.Luggage,
                Model = c.Model,
                Seat = c.Seat,
                Transmission = c.Transmission,
                BigImageUrl = c.BigImageUrl
            }).ToList();

        }
    }
}
