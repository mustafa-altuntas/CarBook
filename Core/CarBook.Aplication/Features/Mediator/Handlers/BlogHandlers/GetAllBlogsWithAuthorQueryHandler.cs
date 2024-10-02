using CarBook.Aplication.Features.Mediator.Queries.BlogQueries;
using CarBook.Aplication.Features.Mediator.Results.BlogResults;
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
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            List<Blog> values = _repository.GetAllBlogsWithAuthors();
            return values.Select(a => new GetAllBlogsWithAuthorQueryResult
            {
                BlogID = a.BlogID,
                Title = a.Title,
                Description=a.Description,
                CoverImageUrl = a.CoverImageUrl,
                CreatedDate = a.CreatedDate,
                AuthorID = a.AuthorID,
                AuthorName = a.Author.Name,
                CategoryID = a.CategoryID,
                CategoryName = a.Category.Name,
                AuthorDescription = a.Author.Description,
                AuthorImageUrl= a.Author.ImageUrl,
            }).ToList();
        }
    }
}
