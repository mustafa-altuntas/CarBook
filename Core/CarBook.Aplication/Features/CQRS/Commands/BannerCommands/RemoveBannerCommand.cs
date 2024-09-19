using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommand
    {
        public int BannerId { get; set; }

    }
}
