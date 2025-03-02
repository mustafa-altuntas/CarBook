using CarBook.Aplication.Features.Mediator.Commands.ReservationCommands;
using CarBook.Aplication.Features.Mediator.Queries.ReservationQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        private readonly IMediator mediator;

        public ReservationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservation()
        {
            var values = await mediator.Send(new GetReservationQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await mediator.Send(command);
            return Ok("Rezervasyon bilgisi oluşturuldu.");
        }

    }
}
