using CarBook.Aplication.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Aplication.Features.Mediator.Results.CarFeatureResults;
using CarBook.Aplication.Interfaces;
using CarBook.Aplication.Interfaces.CarFeatureInterfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {

        private readonly ICarFeatureRepository _repository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarFeatureByCarId(request.CarId);
            return values.Select(x=> new GetCarFeatureByCarIdQueryResult
            {
                CarId = x.CarId,
                Available=x.Available,
                FeatureId=x.FeatureId,
                //FeatureName
            }).ToList();
        }
    }
}
