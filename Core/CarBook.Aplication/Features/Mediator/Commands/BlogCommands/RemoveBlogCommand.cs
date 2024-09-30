using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Commands.BlogCommands
{
    public class RemoveBlogCommand:IRequest
    {
        public int BlogID { get; set; }

    }
}
