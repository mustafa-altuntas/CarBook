using CarBook.Aplication.Features.Mediator.Queries.RentACarQueries;
using CarBook.Aplication.Features.Mediator.Results.RentACarResults;
using CarBook.Aplication.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(rc=>rc.LocationId==request.LocationId && rc.Available==request.Available);
            return values.Select(rc =>
                new GetRentACarQueryResult { CarId = rc.CarId }
            ).ToList();
        }
    }
}
