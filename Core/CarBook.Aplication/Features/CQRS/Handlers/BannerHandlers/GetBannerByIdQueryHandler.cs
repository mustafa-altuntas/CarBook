using CarBook.Aplication.Features.CQRS.Queries.BannerQueries;
using CarBook.Aplication.Features.CQRS.Results.BannerResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handler(GetBannerByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                BannerId = value.BannerId,
                Description = value.Description,
                Title = value.Title,
                VideoDescription = value.VideoDescription,
                VideoUrl = value.VideoUrl
            };
        }
    }
}
