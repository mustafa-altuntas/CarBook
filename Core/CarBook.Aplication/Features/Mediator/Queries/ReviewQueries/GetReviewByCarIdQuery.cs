using CarBook.Aplication.Features.Mediator.Results.ReviewResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.ReviewQueries
{
    public class GetReviewByCarIdQuery:IRequest<List<GetReviewByCarIdQueryResult>>
    {
        public int CarId { get; set; }

        public GetReviewByCarIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}
