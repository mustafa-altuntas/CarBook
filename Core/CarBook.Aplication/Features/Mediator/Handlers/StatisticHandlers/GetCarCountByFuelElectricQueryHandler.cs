using CarBook.Aplication.Features.Mediator.Queries.StatisticQueries;
using CarBook.Aplication.Features.Mediator.Results.StatisticResults;
using CarBook.Aplication.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CarBook.Aplication.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountByFuelElectricQueryHandler : IRequestHandler<GetCarCountByFuelElectticQuery, GetCarCountByFuelElectticQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetCarCountByFuelElectricQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFuelElectticQueryResult> Handle(GetCarCountByFuelElectticQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByFuelElecttic();
            return new GetCarCountByFuelElectticQueryResult
            {
                CarCountByFuelElecttic = value
            };
        }
    }
}
