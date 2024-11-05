using CarBook.Aplication.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarController : ControllerBase
    {
        private readonly IMediator mediator;

        public RentACarController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("RentACarListByLocation")]
        public async Task<IActionResult> RentACarListByLocation(string location, bool available)
        {
            var values = await mediator.Send(new GetRentACarQuery { Location= location, Available= available });
            return Ok(values);
        }


    }
}
