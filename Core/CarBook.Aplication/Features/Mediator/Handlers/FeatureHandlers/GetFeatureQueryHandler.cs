using CarBook.Aplication.Features.Mediator.Queries.FeatureQueries;
using CarBook.Aplication.Features.Mediator.Results.FeatureResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using MediatR;


namespace CarBook.Aplication.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(f => new GetFeatureQueryResult
            {
                FeatureId = f.FeatureId,
                Name = f.Name
            }).ToList();
        }
    }
}
