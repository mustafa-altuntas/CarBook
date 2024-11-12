using CarBook.Aplication.Features.Mediator.Results.CarFeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.CarFeatureQueries
{
    public class GetCarFeatureByCarIdQuery:IRequest<List<GetCarFeatureByCarIdQueryResult>>
    {
        public int CarId { get; set; }

        public GetCarFeatureByCarIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}
