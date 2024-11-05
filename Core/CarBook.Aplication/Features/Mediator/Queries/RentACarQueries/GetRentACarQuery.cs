using CarBook.Aplication.Features.Mediator.Results.RentACarResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.RentACarQueries
{
    public class GetRentACarQuery:IRequest<GetRentACarQueryResult>
    {
    }
}
