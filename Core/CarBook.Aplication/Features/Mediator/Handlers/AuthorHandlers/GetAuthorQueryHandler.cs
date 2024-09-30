using CarBook.Aplication.Features.Mediator.Queries.AuthorQueries;
using CarBook.Aplication.Features.Mediator.Results.AuthorResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(a => new GetAuthorQueryResult
            {
                AuthorID = a.AuthorID,
                Description = a.Description,
                ImageUrl = a.ImageUrl,
                Name = a.Name
            }).ToList();
        }
    }
}
