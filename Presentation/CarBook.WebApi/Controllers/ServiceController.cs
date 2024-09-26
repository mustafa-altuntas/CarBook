﻿using CarBook.Aplication.Features.Mediator.Commands.ServiceCommands;
using CarBook.Aplication.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {


        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value = await _mediator.Send(new GetServiceQuery());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis bilgisi oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis bilgisi güncelendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveService(RemoveServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis bilgisi silindi.");
        }






    }
}
