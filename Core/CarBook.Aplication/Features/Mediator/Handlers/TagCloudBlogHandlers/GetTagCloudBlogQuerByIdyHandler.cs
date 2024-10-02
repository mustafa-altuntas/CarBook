using CarBook.Aplication.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Aplication.Features.Mediator.Queries.TagCloudBlogQueries;
using CarBook.Aplication.Features.Mediator.Results.SocialMediaResults;
using CarBook.Aplication.Features.Mediator.Results.TagCloudBlogResults;
using CarBook.Aplication.Interfaces.TagCloudBlogInterfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.TagCloudBlogHandlers
{
    public class GetTagCloudBlogQuerByIdyHandler : IRequestHandler<GetTagCloudBlogByIdQuery, List<GetTagCloudBlogBIdQueryResult>>
    {


        private readonly ITagCloudBlogRepository _repository;

        public GetTagCloudBlogQuerByIdyHandler(ITagCloudBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudBlogBIdQueryResult>> Handle(GetTagCloudBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetTagCloudBlogsWithTagById(request.BlogId);
            return values.Select(x => new GetTagCloudBlogBIdQueryResult
            {
                TagCloudBlogID = x.TagCloudBlogID,
                TagTitle = x.TagCloud.Title,
            }).ToList();
        }
    }
}
