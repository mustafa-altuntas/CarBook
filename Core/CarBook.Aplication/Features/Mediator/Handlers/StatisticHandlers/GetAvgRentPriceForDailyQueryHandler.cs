using CarBook.Aplication.Features.Mediator.Queries.StatisticQueries;
using CarBook.Aplication.Features.Mediator.Results.StatisticResults;
using CarBook.Aplication.Interfaces.StatisticInterfaces;
using MediatR;


namespace CarBook.Aplication.Features.Mediator.Handlers.StatisticHandlers
{
    internal class GetAvgRentPriceForDailyQueryHandler : IRequestHandler<GetAvgRentPriceForDailyQuery, GetAvgRentPriceForDailyQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetAvgRentPriceForDailyQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceForDailyQueryResult> Handle(GetAvgRentPriceForDailyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceForDaily();
            return new GetAvgRentPriceForDailyQueryResult
            {
                AvgRentPriceForDaily = value
            };
        }
    }
}
