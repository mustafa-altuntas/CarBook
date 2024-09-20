using CarBook.Aplication.Features.CQRS.Results.CarResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handler()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(c => new GetCarQueryResult
            {
                CarId = c.CarId,
                BrandId = c.BrandId,
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
