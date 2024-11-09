using CarBook.Aplication.Features.Mediator.Results.CarPricingResults;
using CarBook.Aplication.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Aplication.Interfaces.CarPricingInterfaces;

namespace CarBook.Aplication.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GerCarPricingWithTimePeriodQueryResult>>
    {

        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GerCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithTimePeriod();
            return values.Select(x => new GerCarPricingWithTimePeriodQueryResult
            {
                Model = x.Model,
                Brand = x.Brand,
                CoverImageUrl = x.CoverImageUrl,
                DailyAmount = x.Daily,
                WeeklyAmount = x.Weekly,
                MonthlAmount = x.Monthly
            }).ToList();
            
        }
    }
}
