using CarBook.Aplication.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Aplication.Features.Mediator.Results.SocialMediaResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        async Task<List<GetSocialMediaQueryResult>> IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>.Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(s=> new GetSocialMediaQueryResult
            {
                SocialMediaId = s.SocialMediaId,
                Icon = s.Icon,
                Name = s.Name,
                Url = s.Url
            }).ToList();
        }
    }
}
