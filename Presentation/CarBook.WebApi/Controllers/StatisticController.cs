using CarBook.Aplication.Features.Mediator.Queries.StatisticQueries;
using CarBook.Aplication.Interfaces.StatisticInterfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IMediator mediator;

        public StatisticController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetAllStatistics")]
        public async Task<IActionResult> GetAllStatistics()
        {
            var value = await mediator.Send(new GetAllStatisticsQuery());
            return Ok(value);
        }

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var value = await mediator.Send(new GetCarCountQuery());
            return Ok(value);
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var value = await mediator.Send(new GetLocationCountQuery());
            return Ok(value);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var value = await mediator.Send(new GetAuthorCountQuery());
            return Ok(value);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var value = await mediator.Send(new GetBlogCountQuery());
            return Ok(value);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var value = await mediator.Send(new GetBrandCountQuery());
            return Ok(value);
        }

        [HttpGet("GetAvgRentPriceForDaily")]
        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            var value = await mediator.Send(new GetAvgRentPriceForDailyQuery());
            return Ok(value);
        }

        [HttpGet("GetAvgRentPriceForWeekly")]
        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var value = await mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(value);
        }

        [HttpGet("GetAvgRentPriceForMonthly")]
        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            var value = await mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            return Ok(value);
        }

        [HttpGet("GetCarCountByTransmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTransmissionIsAuto()
        {
            var value = await mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            return Ok(value);
        }

        [HttpGet("GetBrandNameByMaxCar")]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var value = await mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(value);
        }

        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            var value = await mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(value);
        }

        [HttpGet("GetCarCountByKmSmallerThen1000")]
        public async Task<IActionResult> GetCarCountByKmSmallerThen1000()
        {
            var value = await mediator.Send(new GetCarCountByKmSmallerThen1000Query());
            return Ok(value);
        }

        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var value = await mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(value);
        }

        [HttpGet("GetCarCountByFuelElecttic")]
        public async Task<IActionResult> GetCarCountByFuelElecttic()
        {
            var value = await mediator.Send(new GetCarCountByFuelElectticQuery());
            return Ok(value);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var value = await mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(value);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var value = await mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            return Ok(value);
        }



    }
}
