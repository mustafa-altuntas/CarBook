using CarBook.Aplication.Features.Mediator.Commands.ReviewCommands;
using CarBook.Aplication.Features.Mediator.Queries.ReviewQueries;
using CarBook.Aplication.Validators.ReviewValidators;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ReviewListByCarId")]
        public async Task<IActionResult> ReviewListByCarId(int carId)
        {
            var values = await _mediator.Send(new GetReviewByCarIdQuery(carId));
            return Ok(values);
        }

        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            await _mediator.Send(command);
            return Ok("Değerlendirme başarıyla kaydedildi.");
        }

        [HttpPut("UpdateReview")]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
        {
            await _mediator.Send(command);
            return Ok("Değerlendirme başarıyla güncellendi.");
        }

    }
}
