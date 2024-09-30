using CarBook.Aplication.Features.Mediator.Queries.BlogQueries;
using CarBook.Aplication.Features.Mediator.Results.BlogResults;
using CarBook.Aplication.Interfaces;
using CarBook.Aplication.Interfaces.BlogInterfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogsWhitAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWhitAuthorsQuery, List<GetLast3BlogsWhitAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast3BlogsWhitAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogsWhitAuthorsQueryResult>> Handle(GetLast3BlogsWhitAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast3BlogsWhitAuthors();

            return  values.Select(a => new GetLast3BlogsWhitAuthorsQueryResult
            {

                BlogID = a.BlogID,
                AuthorID = a.AuthorID,
                CategoryID = a.CategoryID,
                CoverImageUrl = a.CoverImageUrl,
                Title = a.Title,
                CreatedDate = a.CreatedDate,
                AuthorName = a.Author.Name,

            }).ToList();
        }
    }
}
