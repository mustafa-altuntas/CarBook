using CarBook.Aplication.Features.Mediator.Results.CarDescriptionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByCarIdQuery:IRequest<GetCarDescriptionQueryResult>
    {
        public int CarId { get; set; }

        public GetCarDescriptionByCarIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}
