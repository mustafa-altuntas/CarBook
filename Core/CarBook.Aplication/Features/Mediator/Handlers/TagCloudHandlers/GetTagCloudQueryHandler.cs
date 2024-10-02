using CarBook.Aplication.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Aplication.Features.Mediator.Results.TagCloudResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        async Task<List<GetTagCloudQueryResult>> IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>.Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(s=> new GetTagCloudQueryResult
            {
                Title = s.Title,
                BlogID = s.BlogID,
                TagCloudID= s.TagCloudID,
            }).ToList();
        }
    }
}
