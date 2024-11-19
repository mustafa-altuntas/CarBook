
using CarBook.Aplication.Features.Mediator.Commands.BlogCommands;
using CarBook.Aplication.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {


        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [AllowAnonymous]
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _mediator.Send(new RemoveBlogCommand() { BlogID = id });
            return Ok("Blog bilgisi silindi.");
        }

        [AllowAnonymous]
        [HttpGet("GetLast3BlogsWhitAuthorsList")]
        public async Task<IActionResult> GetLast3BlogsWhitAuthorsList()
        {
            var values = await _mediator.Send(new GetLast3BlogsWhitAuthorsQuery());
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("GetAllBlogsWithAuthorList")]
        public async Task<IActionResult> GetAllBlogsWithAuthorList()
        {
            var values = await _mediator.Send(new GetAllBlogsWithAuthorQuery());
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("GetBlogByIdWithAuthor")]
        public async Task<IActionResult> GetBlogByIdWithAuthor(int id)
        {
            // id = blogId
            var values = await _mediator.Send(new GetBlogByIdWithAuthorQuery(id));
            return Ok(values);
        }






    }
}
