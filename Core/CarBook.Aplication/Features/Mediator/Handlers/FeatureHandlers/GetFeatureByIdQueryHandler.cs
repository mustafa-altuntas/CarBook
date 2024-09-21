using CarBook.Aplication.Features.Mediator.Queries.FeatureQueries;
using CarBook.Aplication.Features.Mediator.Results.FeatureResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using MediatR;

namespace CarBook.Aplication.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FeatureId);
            return new GetFeatureByIdQueryResult { FeatureId = value.FeatureId, Name = value.Name };
        }
    }
}
