using CarBook.Aplication.Features.Mediator.Queries.TagCloudBlogQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudBlogController : Controller
    {
        private readonly IMediator _mediator;

        public TagCloudBlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTagCloudBlogsWithTagById")]
        public async Task<IActionResult> GetTagCloudBlogWithCarsList(int id)
        {
            var values = await _mediator.Send(new GetTagCloudBlogByIdQuery(id));
            return Ok(values);
        }
    }
}


