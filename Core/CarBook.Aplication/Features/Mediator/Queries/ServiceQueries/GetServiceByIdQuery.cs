using CarBook.Aplication.Features.Mediator.Results.ServiceResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceByIdQuery : IRequest<GetServiceByIdQueryResult>
    {
        public int ServiceID { get; set; }

        public GetServiceByIdQuery(int serviceID)
        {
            ServiceID = serviceID;
        }
    }
}
