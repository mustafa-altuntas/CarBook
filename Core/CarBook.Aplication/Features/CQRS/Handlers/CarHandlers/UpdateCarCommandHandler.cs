using CarBook.Aplication.Features.CQRS.Commands.CarCommands;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handler(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarId);

            value.BrandId = command.BrandId;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Fuel = command.Fuel;
            value.Km = command.Km;
            value.Luggage = command.Luggage;
            value.Model = command.Model;
            value.Seat = command.Seat;
            value.Transmission = command.Transmission;
            value.BigImageUrl = command.BigImageUrl;

            await _repository.UpdateAsync(value);
        }
    }
}
