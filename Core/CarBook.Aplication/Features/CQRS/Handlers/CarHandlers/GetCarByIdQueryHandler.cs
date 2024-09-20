using CarBook.Aplication.Features.CQRS.Queries.CarQueries;
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
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarQueryResult> Handler(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.CarId);
            return new GetCarQueryResult
            {
                CarId = values.CarId,
                BrandId = values.BrandId,
                CoverImageUrl = values.CoverImageUrl,
                Fuel = values.Fuel,
                Km = values.Km,
                Luggage = values.Luggage,
                Model = values.Model,
                Seat = values.Seat,
                Transmission = values.Transmission,
                BigImageUrl = values.BigImageUrl
            };

        }
    }
}
