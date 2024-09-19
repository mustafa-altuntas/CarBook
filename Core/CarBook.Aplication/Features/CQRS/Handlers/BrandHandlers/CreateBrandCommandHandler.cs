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
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handler(CreateBrandCommand command)
        {
            var value = new Brand();
            value.Name = command.Name;
            await _repository.CreateAsync(value);
        }
    }
}
