using CarBook.Aplication.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Aplication.Features.Mediator.Results.FooterAddressResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(f => new GetFooterAddressQueryResult
            {
                Address = f.Address,
                Description = f.Description,
                Email = f.Email,
                FooterAddressId = f.FooterAddressId,
                Phone = f.Phone
            }).ToList();
        }
    }
}
