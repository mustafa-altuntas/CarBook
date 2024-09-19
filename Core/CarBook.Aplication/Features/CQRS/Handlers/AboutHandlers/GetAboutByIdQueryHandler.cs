using CarBook.Aplication.Features.CQRS.Queries.AboutQuerys;
using CarBook.Aplication.Features.CQRS.Results.AboudResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handler(GetAboutByIdQuery query)
        {
            var about = await _repository.GetByIdAsync(query.Id);
            return new() {
                AboutId=about.AboutId,
                Description=about.Description,
                ImageUrl=about.ImageUrl,
                Title=  about.Title
            };
        }


    }
}
