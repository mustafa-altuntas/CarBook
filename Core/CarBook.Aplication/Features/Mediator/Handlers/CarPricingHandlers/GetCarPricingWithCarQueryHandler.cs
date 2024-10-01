using CarBook.Aplication.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Aplication.Features.Mediator.Results.CarPricingResults;
using CarBook.Aplication.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = _carPricingRepository.GetAllCarPricingsWithCars();
            return values.Select(cp => new GetCarPricingWithCarQueryResult
            {
                Amount = cp.Amount,
                Brand = cp.Car.Brand.Name,
                CarPricingId = cp.CarPricingId,
                CoverImageUrl = cp.Car.CoverImageUrl,
                Model=cp.Car.Model
            }).ToList();
        }
    }
}
