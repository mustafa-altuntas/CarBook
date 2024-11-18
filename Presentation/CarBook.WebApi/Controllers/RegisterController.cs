using CarBook.Aplication.Features.Mediator.Commands.AppUserCommands;
using CarBook.Aplication.Features.Mediator.Queries.AppUserQueries;
using CarBook.Aplication.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly IMediator mediator;

        public RegisterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateAppUserCommand command)
        {
            await mediator.Send(command);

            return Ok("Kullanıcı başarıyla oluşturuldu.");
        }

    }
}
