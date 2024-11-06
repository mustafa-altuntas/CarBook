﻿using CarBook.Aplication.Features.Mediator.Commands.ReservationCommands;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler:IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var value = new Reservation()
            {
                Surname = request.Surname,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                DropOffLocationId = request.DropOffLocationId,
                PickUpLocationId = request.PickUpLocationId,
                CarId = request.CarId,
                Age = request.Age,
                DriverLicenseYear = request.DriverLicenseYear,
                Description = request.Description
            };

            await _repository.CreateAsync(value);
        }
    }
}
