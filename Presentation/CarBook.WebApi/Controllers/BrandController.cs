﻿using CarBook.Aplication.Features.CQRS.Commands.BrandCommands;
using CarBook.Aplication.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Aplication.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;

        public BrandController(CreateBrandCommandHandler createBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler, RemoveBrandCommandHandler removeBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
        }



        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHandler.Handler();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var value = await _getBrandByIdQueryHandler.Handler(new GetBrandByIdQuery(id));
            return Ok(value);
        }




        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handler(command);
            return Ok("Marka bilgisi eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handler(command);
            return Ok("Marka bilgisi güncellendi.");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(RemoveBrandCommand command)
        {
            await _removeBrandCommandHandler.Handler(command);
            return Ok("Marka bilgisi silindi.");

        }




    }
}