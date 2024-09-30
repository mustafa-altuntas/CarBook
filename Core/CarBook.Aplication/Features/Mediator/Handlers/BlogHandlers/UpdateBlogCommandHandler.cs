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
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogID);

            value.AuthorID = request.AuthorID;
            value.CategoryID = request.CategoryID;
            value.CoverImageUrl = request.CoverImageUrl;
            value.Title = request.Title;
            value.CreatedDate = request.CreatedDate;




            await _repository.UpdateAsync(value);
        }
    }
}
