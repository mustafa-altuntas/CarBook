using CarBook.Aplication.Features.Mediator.Commands.CommentCommands;
using CarBook.Aplication.Features.RepositoryPattern;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.CommentHandlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IGenericRepository<Comment> _repository;

        public CreateCommentCommandHandler(IGenericRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            _repository.Create(new Comment()
            {
                Name = request.Name,
                CreatedDate = request.CreatedDate,
                Description = request.Description,
                BlogID = request.BlogID,

            });
            
        }
    }
}
