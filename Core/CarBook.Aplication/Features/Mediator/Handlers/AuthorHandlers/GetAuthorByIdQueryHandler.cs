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
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return  new GetAuthorByIdQueryResult
            {
                AuthorID = value.AuthorID,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Name = value.Name
            };
        }
    }
}
