using CarBook.Aplication.Features.Mediator.Results.StatisticResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.StatisticQueries
{
    public class GetAllStatisticsQuery:IRequest<GetAllStatisticsQueryResult>
    {
    }
}
