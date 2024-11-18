using CarBook.Aplication.Features.Mediator.Queries.AppUserQueries;
using CarBook.Aplication.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IMediator mediator;

        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Index(GetCheckAppUserQuery query)
        {
            var value = await mediator.Send(query);
            if(value.IsExist)
            {
                return Created("", JwtTokenGenerator.GenerateToken(value));
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalıdır.");
            }
        }

    }
}
