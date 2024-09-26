using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Commands.SocialMediaCommands
{
    public class RemoveSocialMediaCommand:IRequest
    {
        public int SocialMediaId { get; set; }
    }
}
