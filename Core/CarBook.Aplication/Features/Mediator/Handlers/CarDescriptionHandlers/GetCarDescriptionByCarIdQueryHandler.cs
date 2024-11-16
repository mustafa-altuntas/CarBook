using CarBook.Aplication.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Aplication.Features.Mediator.Results.CarDescriptionResults;
using CarBook.Aplication.Interfaces;
using CarBook.Aplication.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
    {

        private readonly ICarDescriptionRepository _repository;

        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarDescription(request.CarId);
            return new GetCarDescriptionByCarIdQueryResult
            {
                CarId = value.CarId,
                CarDescriptionId = value.CarDescriptionId,
                Detail = value.Detail,
            };
        }
    }
}
