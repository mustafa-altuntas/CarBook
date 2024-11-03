
using CarBook.Aplication.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Aplication.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {


        private readonly IMediator _mediator;

        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans medya bilgisi oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans medya bilgisi güncelendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommand() { TestimonialId = id });
            return Ok("Referans medya bilgisi silindi.");
        }






    }
}
