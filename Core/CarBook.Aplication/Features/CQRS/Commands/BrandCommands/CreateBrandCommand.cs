using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Commands.BrandCommands
{
    public class CreateBrandCommand
    {
        public string Name { get; set; }
    }
}
