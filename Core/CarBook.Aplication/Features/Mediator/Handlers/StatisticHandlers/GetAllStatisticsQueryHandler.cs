using CarBook.Aplication.Features.Mediator.Queries.StatisticQueries;
using CarBook.Aplication.Features.Mediator.Results.StatisticResults;
using CarBook.Aplication.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetAllStatisticsQueryHandler : IRequestHandler<GetAllStatisticsQuery, GetAllStatisticsQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetAllStatisticsQueryHandler(IStatisticRepository? repository)
        {
            _repository = repository;
        }

        public async Task<GetAllStatisticsQueryResult> Handle(GetAllStatisticsQuery request, CancellationToken cancellationToken)
        {
            var result = new GetAllStatisticsQueryResult();
            result.CarCount = _repository.GetCarCount();
            result.LocationCount = _repository.GetLocationCount();
            result.AuthorCount = _repository.GetAuthorCount();
            result.BlogCount = _repository.GetBlogCount();
            result.BrandCount = _repository.GetBrandCount();
            result.AvgRentPriceForDaily = _repository.GetAvgRentPriceForDaily();
            result.AvgRentPriceForWeekly = _repository.GetAvgRentPriceForWeekly();
            result.AvgRentPriceForMonthly = _repository.GetAvgRentPriceForMonthly();
            result.CarCountByTransmissionIsAuto = _repository.GetCarCountByTransmissionIsAuto();
            result.BrandNameByMaxCar = _repository.GetBrandNameByMaxCar();
            result.BlogTitleByMaxBlogComment = _repository.GetBlogTitleByMaxBlogComment();
            result.CarCountByKmSmallerThen1000 = _repository.GetCarCountByKmSmallerThen1000();
            result.CarCountByFuelGasolineOrDiesel = _repository.GetCarCountByFuelGasolineOrDiesel();
            result.CarCountByFuelElecttic = _repository.GetCarCountByFuelElecttic();
            result.CarBrandAndModelByRentPriceDailyMax = _repository.GetCarBrandAndModelByRentPriceDailyMax();
            result.CarBrandAndModelByRentPriceDailyMin = _repository.GetCarBrandAndModelByRentPriceDailyMin();

            return result;
        }
    }
}
