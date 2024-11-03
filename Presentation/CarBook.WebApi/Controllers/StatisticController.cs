using CarBook.Aplication.Features.Mediator.Queries.StatisticQueries;
using CarBook.Aplication.Interfaces.StatisticInterfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IStatisticRepository statisticRepository;

        public StatisticController(IMediator mediator, IStatisticRepository statisticRepository)
        {
            this.mediator = mediator;
            this.statisticRepository = statisticRepository;
        }

        [HttpGet("GetCarCount")]
        public IActionResult GetCarCount()
        {
            var value = mediator.Send(new GetCarCountQuery());
            return Ok(value);
        }


        [HttpGet("GetBrandNameByMaxCar")]
        public IActionResult GetBrandNameByMaxCar()
        {
            var value = statisticRepository.GetBrandNameByMaxCar();
            return Ok(value);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public IActionResult GetCarBrandAndModelByRentPriceDailyMax()
        {
            var value = statisticRepository.GetCarBrandAndModelByRentPriceDailyMax();
            return Ok(value);
        }


        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public IActionResult GetCarBrandAndModelByRentPriceDailyMin()
        {
            var value = statisticRepository.GetCarBrandAndModelByRentPriceDailyMin();
            return Ok(value);
        }



        [HttpGet("BlogTitleByMaxBlogComment")]
        public IActionResult BlogTitleByMaxBlogComment()
        {
            var value = statisticRepository.BlogTitleByMaxBlogComment();
            return Ok(value);
        }




    }
}
