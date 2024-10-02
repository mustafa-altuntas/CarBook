using CarBook.Aplication.Features.Mediator.Queries.BlogQueries;
using CarBook.Aplication.Features.Mediator.Results.BlogResults;
using CarBook.Aplication.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdWithAuthorQueryHandler : IRequestHandler<GetBlogByIdWithAuthorQuery, GetBlogByIdWithAuthorQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetBlogByIdWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdWithAuthorQueryResult> Handle(GetBlogByIdWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetBlogByIdWithAuthor(request.Id);
            return new GetBlogByIdWithAuthorQueryResult
            {
                AuthorDescription = values.Author.Description,
                AuthorID = values.AuthorID,
                AuthorImageUrl = values.Author.ImageUrl,
                AuthorName = values.Author.Name,
                BlogID = values.BlogID,

            };
        }
    }
}
