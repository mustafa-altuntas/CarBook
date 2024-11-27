using CarBook.Aplication.Features.CQRS.Commands.CarCommands;
using CarBook.Aplication.Features.CQRS.Handlers.CarHandlers;
using CarBook.Aplication.Features.CQRS.Queries.CarQueries;
using CarBook.Aplication.Features.Mediator.Queries.StatisticQueries;
using CarBook.WebApi.Hubs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CarBook.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLast5CarsWhithBrandsQueryHandler _getLast5CarsWhithBrandsQueryHandler;


        private readonly IHubContext<CarHub> _hubContext;



        public CarController(CreateCarCommandHandler createCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, RemoveCarCommandHandler removeCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarsWhithBrandsQueryHandler getLast5CarsWhithBrandsQueryHandler, IHubContext<CarHub> hubContext)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLast5CarsWhithBrandsQueryHandler = getLast5CarsWhithBrandsQueryHandler;
            _hubContext = hubContext;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handler();
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handler(new GetCarByIdQuery(id));
            return Ok(value);
        }




        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handler(command);

            await _hubContext.Clients.All.SendAsync("RefreshCarCount");


            return Ok("Araç bilgisi eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handler(command);
            return Ok("Araç bilgisi güncellendi.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _removeCarCommandHandler.Handler(new RemoveCarCommand() { CarId=id});
            
            await _hubContext.Clients.All.SendAsync("RefreshCarCount");

            return Ok("Araç bilgisi silindi.");

        }

        [AllowAnonymous]
        [HttpGet("CarListWithBrand")]
        public IActionResult CarListWithBrand()
        {
            var values = _getCarWithBrandQueryHandler.Handler();
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("GetLast5CarsWhithBrands")]
        public IActionResult GetLast5CarsWhithBrands()
        {
            var values = _getLast5CarsWhithBrandsQueryHandler.Handler();
            return Ok(values);
        }




    }
}
