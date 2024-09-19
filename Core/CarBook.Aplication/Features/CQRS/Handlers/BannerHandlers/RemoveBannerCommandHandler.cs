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
    public class RemoveBannerCommandHandler
    {

        private readonly IRepository<Banner> _repository;

        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }


        public async Task Handler(RemoveBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.BannerId);
            if(value is not null)
            {
                await _repository.RemoveAsync(value);
            }
        }

    }
}
