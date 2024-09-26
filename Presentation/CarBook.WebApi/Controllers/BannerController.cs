﻿using CarBook.Aplication.Features.CQRS.Commands.BannerCommands;
using CarBook.Aplication.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Aplication.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;

        public BannerController(CreateBannerCommandHandler createBannerCommandHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, RemoveBannerCommandHandler removeBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler)
        {
            _createBannerCommandHandler = createBannerCommandHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
        }



        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handler();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _getBannerByIdQueryHandler.Handler(new GetBannerByIdQuery(id));
            return Ok(value);
        }

        
        

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommad command)
        {
            await _createBannerCommandHandler.Handler(command);
            return Ok("Afiş bilgisi eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handler(command);
            return Ok("Afiş bilgisi güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(RemoveBannerCommand command)
        {
            await _removeBannerCommandHandler.Handler(command);
            return Ok("Afiş bilgisi silindi.");
        }




    }
}