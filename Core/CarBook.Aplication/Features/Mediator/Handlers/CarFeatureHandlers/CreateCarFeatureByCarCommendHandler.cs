using CarBook.Aplication.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Aplication.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureByCarCommendHandler : IRequestHandler<CreateCarFeatureByCarCommend>
    {
        private readonly ICarFeatureRepository _repository;

        public CreateCarFeatureByCarCommendHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarFeatureByCarCommend request, CancellationToken cancellationToken)
        {
            _repository.CreateCarFeatureByCar(new Domain.CarFeature
            {
                Available = false,
                CarId = request.CarId,
                FeatureId = request.FeatureId,
            });
        }
    }
}
