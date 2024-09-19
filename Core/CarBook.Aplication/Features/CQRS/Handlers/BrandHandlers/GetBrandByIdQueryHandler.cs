using CarBook.Aplication.Features.CQRS.Queries.BrandQueries;
using CarBook.Aplication.Features.CQRS.Results.BrandResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandByIdQueryResult> Handler(GetBrandByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetBrandByIdQueryResult
            {
                BrandId = value.BrandId,
                Cars = value.Cars,
                Name = value.Name,
            };
        }



    }
}
