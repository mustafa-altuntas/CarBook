using CarBook.Aplication.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Aplication.Features.Mediator.Results.TestimonialResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }


        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(t => new GetTestimonialQueryResult
            {
                Comment = t.Comment,
                ImageUrl = t.ImageUrl,
                Name = t.Name,
                TestimonialId = t.TestimonialId,
                Title = t.Title
            }).ToList();
        }
    }
}
