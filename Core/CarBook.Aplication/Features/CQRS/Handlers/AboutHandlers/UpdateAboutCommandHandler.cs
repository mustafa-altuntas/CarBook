using CarBook.Aplication.Features.CQRS.Commands.AboutCommands;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handler(UpdateAboutCommand command)
        {
            var about = await _repository.GetByIdAsync(command.AboudId);
            about.Title = command.Title;
            about.Description = command.Description;
            about.ImageUrl = command.ImageUrl;

            await _repository.UpdateAsync(about);
        }
    }
}
