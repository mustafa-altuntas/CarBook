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
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }


        public async Task<List<GetBannerQueryResult>> Handler()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(v => new GetBannerQueryResult
            {
                BannerId = v.BannerId,
                Description = v.Description,
                Title = v.Title,
                VideoDescription = v.VideoDescription,
                VideoUrl = v.VideoUrl
            }).ToList();
        }
    }
}
