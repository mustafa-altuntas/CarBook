﻿
using CarBook.Aplication.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Aplication.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {


        private readonly IMediator _mediator;

        public SocialMediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value = await _mediator.Send(new GetSocialMediaQuery());
            return Ok(value);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            var value = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sosyal medya bilgisi oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sosyal medya bilgisi güncelendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _mediator.Send(new RemoveSocialMediaCommand() { SocialMediaId = id });
            return Ok("Sosyal medya bilgisi silindi.");
        }






    }
}
