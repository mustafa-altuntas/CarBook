using CarBook.Aplication.Features.Mediator.Queries.ReviewQueries;
using CarBook.Aplication.Features.Mediator.Results.ReviewResults;
using CarBook.Aplication.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _repository;

        public GetReviewByCarIdQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetReviewByCarId(request.CarId);
            return values.Select(r=> new GetReviewByCarIdQueryResult
            {
                CarId = r.CarId,
                Comment = r.Comment,
                CustomerImage = r.CustomerImage,
                CustomerName = r.CustomerName,
                RaytingValue = r.RaytingValue,
                ReviewDate=r.ReviewDate,
                ReviewId=r.ReviewId
            }).ToList();
        }
    }
}
