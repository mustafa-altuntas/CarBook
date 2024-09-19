using CarBook.Aplication.Features.CQRS.Commands.BannerCommands;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handler(CreateBannerCommad commad)
        {
            Banner banner = new Banner();
            banner.VideoUrl = commad.VideoUrl;
            banner.Title = commad.Title;
            banner.Description = commad.Description; 
            banner.VideoDescription = commad.VideoDescription; 

            await _repository.CreateAsync(banner);
        }
    }
}
