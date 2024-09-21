using CarBook.Aplication.Features.Mediator.Queries.LocationQueries;
using CarBook.Aplication.Features.Mediator.Results.LocationResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using MediatR;


namespace CarBook.Aplication.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _repository;

        public GetLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(l => new GetLocationQueryResult
            {
                LocationId=l.LocationId,
                Name = l.Name
            }).ToList();
        }
    }
}
