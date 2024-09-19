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
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }


        public async Task<List<GetAboutQueryResult>> Handler()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(a => new GetAboutQueryResult
            {
                AboutId = a.AboutId,
                Description = a.Description,
                ImageUrl = a.ImageUrl,
                Title = a.Title
            }).ToList();
        }
    }
}
