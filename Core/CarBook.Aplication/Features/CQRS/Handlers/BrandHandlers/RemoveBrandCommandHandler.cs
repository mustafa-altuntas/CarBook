using CarBook.Aplication.Features.CQRS.Commands.BrandCommands;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handler(RemoveBrandCommand command)
        {
            var value = await _repository.GetByIdAsync(command.BrandId);
            await _repository.RemoveAsync(value);
        }
    }
}
