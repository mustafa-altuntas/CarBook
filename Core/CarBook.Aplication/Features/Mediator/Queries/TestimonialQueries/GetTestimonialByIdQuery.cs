using CarBook.Aplication.Features.Mediator.Results.TestimonialResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery:IRequest<GetTestimonialByIdQueryResult>
    {
        public int TestimonialId { get; set; }

        public GetTestimonialByIdQuery(int testimonialId)
        {
            TestimonialId = testimonialId;
        }
    }
}
