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
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner>? _repository;

        public UpdateBannerCommandHandler(IRepository<Banner>? repository)
        {
            _repository = repository;
        }


        public async Task Handler(UpdateBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.BannerId);

            if (value is not null)
            {
                value.VideoUrl = command.VideoUrl;
                value.Title = command.Title;
                value.Description = command.Description;
                value.VideoDescription = command.VideoDescription;
                value.VideoUrl = command.VideoUrl;

                await _repository.UpdateAsync(value);
            }
        }
    }
}
