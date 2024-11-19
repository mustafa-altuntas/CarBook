using CarBook.Aplication.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Aplication.Features.Mediator.Handlers.CarFeatureHandlers;
using CarBook.Aplication.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeatureController : Controller
    {


        private readonly IMediator _mediator;

        public CarFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("{carId}")]
        public async Task<IActionResult> GetCarFeatureListByCarId(int carId)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(carId));
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("UpdateCarFeatureAvailableChangeToFalse/{id}")]
        public async Task<IActionResult> UpdateCarFeatureAvailableChangeToFalse(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Güncelleme yapıldı.");
        }

        [AllowAnonymous]
        [HttpGet("UpdateCarFeatureAvailableChangeToTrue/{id}")]
        public async Task<IActionResult> UpdateCarFeatureAvailableChangeToTrue(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Güncelleme yapıldı.");
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCar(CreateCarFeatureByCarCommend commend)
        {
            await _mediator.Send(commend);
            return Ok("Kayıt yapıldı.");
        }

    }
}
