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
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBrandQueryResult>> Handler()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(b => new GetBrandQueryResult
            {
                BrandId = b.BrandId,
                Cars = b.Cars,
                Name = b.Name
            }).ToList();
        }
    }
}
