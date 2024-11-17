using CarBook.Aplication.Features.Mediator.Commands.ReviewCommands;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;

        public CreateReviewCommandHandler(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Review
            {
                CarId = request.CarId,
                Comment = request.Comment,
                CustomerImage = request.CustomerImage,
                CustomerName = request.CustomerName,
                RaytingValue = request.RaytingValue,
                ReviewDate = DateTime.Now
            });
        }
    }
}
