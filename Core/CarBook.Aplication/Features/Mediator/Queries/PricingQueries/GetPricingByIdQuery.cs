using CarBook.Aplication.Features.Mediator.Results.PricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
    {
        public int PricingId { get; set; }

        public GetPricingByIdQuery(int pricingId)
        {
            PricingId = pricingId;
        }
    }
}
