using CarBook.Aplication.Features.CQRS.Queries.CategoryQueries;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handler(GetCategoryByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.CategoryId);
            return new Category { CategoryId = value.CategoryId, Name = value.Name };
        }

    }
}
