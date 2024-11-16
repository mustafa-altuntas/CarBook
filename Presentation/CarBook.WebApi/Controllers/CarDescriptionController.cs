using CarBook.Aplication.Features.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionController : Controller
    {
        private readonly IMediator _mediator;

        public CarDescriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarDescriptionByCarId(int carId)
        {
            var values = await _mediator.Send(new GetCarDescriptionByCarIdQuery(carId));
            return Ok(values);
        }
    }
}
