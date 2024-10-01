
using CarBook.Aplication.Features.Mediator.Commands.BlogCommands;
using CarBook.Aplication.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {


        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog bilgisi oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog bilgisi güncelendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSocialMedia(RemoveBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog bilgisi silindi.");
        }

        [HttpGet("GetLast3BlogsWhitAuthorsList")]
        public async Task<IActionResult> GetLast3BlogsWhitAuthorsList()
        {
            var values = await _mediator.Send(new GetLast3BlogsWhitAuthorsQuery());
            return Ok(values);
        }
        
        [HttpGet("GetAllBlogsWithAuthorList")]
        public async Task<IActionResult> GetAllBlogsWithAuthorList()
        {
            var values = await _mediator.Send(new GetAllBlogsWithAuthorQuery());
            return Ok(values);
        }






    }
}
