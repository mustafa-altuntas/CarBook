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


        [HttpGet("GetLocationCount")]
        public IActionResult GetLocationCount()
        {
            var value = statisticRepository.GetLocationCount();
            return Ok(value);
        }
        

        [HttpGet("GetAuthorCount")]
        public IActionResult GetAuthorCount()
        {
            var value = statisticRepository.GetAuthorCount();
            return Ok(value);
        }
        
        [HttpGet("GetBlogCount")]
        public IActionResult GetBlogCount()
        {
            var value = statisticRepository.GetBlogCount();
            return Ok(value);
        }
        
        [HttpGet("GetBrandCount")]
        public IActionResult GetBrandCount()
        {
            var value = statisticRepository.GetBrandCount();
            return Ok(value);
        }
        
        [HttpGet("GetAvgRentPriceForDaily")]
        public IActionResult GetAvgRentPriceForDaily()
        {
            var value = statisticRepository.GetAvgRentPriceForDaily();
            return Ok(value);
        }
        
        [HttpGet("GetAvgRentPriceForWeekly")]
        public IActionResult GetAvgRentPriceForWeekly()
        {
            var value = statisticRepository.GetAvgRentPriceForWeekly();
            return Ok(value);
        }
        
        [HttpGet("GetAvgRentPriceForMonthly")]
        public IActionResult GetAvgRentPriceForMonthly()
        {
            var value = statisticRepository.GetAvgRentPriceForMonthly();
            return Ok(value);
        }
        
        [HttpGet("GetCarCountByTransmissionIsAuto")]
        public IActionResult GetCarCountByTransmissionIsAuto()
        {
            var value = statisticRepository.GetCarCountByTransmissionIsAuto();
            return Ok(value);
        }
        
        [HttpGet("GetBrandNameByMaxCar")]
        public IActionResult GetBrandNameByMaxCar()
        {
            var value = statisticRepository.GetBrandNameByMaxCar();
            return Ok(value);
        }
        
        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public IActionResult GetBlogTitleByMaxBlogComment()
        {
            var value = statisticRepository.GetBlogTitleByMaxBlogComment();
            return Ok(value);
        }
        
        [HttpGet("GetCarCountByKmSmallerThen1000")]
        public IActionResult GetCarCountByKmSmallerThen1000()
        {
            var value = statisticRepository.GetCarCountByKmSmallerThen1000();
            return Ok(value);
        }
        
        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public IActionResult GetCarCountByFuelGasolineOrDiesel()
        {
            var value = statisticRepository.GetCarCountByFuelGasolineOrDiesel();
            return Ok(value);
        }
        
        [HttpGet("GetCarCountByFuelElecttic")]
        public IActionResult GetCarCountByFuelElecttic()
        {
            var value = statisticRepository.GetCarCountByFuelElecttic();
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



    }
}
