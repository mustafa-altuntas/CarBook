
using CarBook.Aplication.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Aplication.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudController : ControllerBase
    {


        private readonly IMediator _mediator;

        public TagCloudController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket bulutu medya bilgisi oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket bulutu medya bilgisi güncelendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSocialMedia(RemoveTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket bulutu medya bilgisi silindi.");
        }






    }
}
