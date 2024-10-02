using CarBook.Aplication.Features.Mediator.Commands.BlogCommands;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = new Blog
            {
                AuthorID = request.AuthorID,
                CategoryID = request.CategoryID,    
                CoverImageUrl = request.CoverImageUrl,
                Title = request.Title,
                Description = request.Description,
                CreatedDate = request.CreatedDate

            };

            await _repository.CreateAsync(value);
        }
    }
}
