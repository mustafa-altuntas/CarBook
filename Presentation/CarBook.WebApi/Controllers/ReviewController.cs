using CarBook.Aplication.Features.Mediator.Queries.ReviewQueries;
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

    }
}
