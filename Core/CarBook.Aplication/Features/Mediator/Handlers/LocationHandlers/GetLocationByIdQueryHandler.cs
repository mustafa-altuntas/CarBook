using CarBook.Aplication.Features.Mediator.Queries.LocationQueries;
using CarBook.Aplication.Features.Mediator.Results.LocationResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using MediatR;

namespace CarBook.Aplication.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.LocationId);
            return new GetLocationByIdQueryResult { LocationId=value.LocationId,Name=value.Name};
        }
    }
}
