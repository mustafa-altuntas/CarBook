using CarBook.Aplication.Features.CQRS.Results.CarResults;
using CarBook.Aplication.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<GetCarWithBrandQueryResult> Handler()
        {
            return _carRepository.GetAllCarWhithBrand().Select(c => new GetCarWithBrandQueryResult
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
