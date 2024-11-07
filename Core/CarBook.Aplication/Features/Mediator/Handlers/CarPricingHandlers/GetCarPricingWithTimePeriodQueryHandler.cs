using CarBook.Aplication.Features.Mediator.Results.CarPricingResults;
using CarBook.Aplication.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GerCarPricingWithTimePeriodQueryResult>>
    {

        public Task<List<GerCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
