using CarBook.Aplication.Features.Mediator.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.CarPricingQueries
{
    public class CarPricingWithTimePeriodQuery:IRequest<List<GerCarPricingWithTimePeriodQueryResult>>
    {

    }
}
