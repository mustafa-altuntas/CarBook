using CarBook.Aplication.Features.Mediator.Results.TagCloudBlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.TagCloudBlogQueries
{
    public class GetTagCloudBlogByIdQuery:IRequest<List<GetTagCloudBlogBIdQueryResult>>
    {
        public int BlogId { get; set; }

        public GetTagCloudBlogByIdQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}
