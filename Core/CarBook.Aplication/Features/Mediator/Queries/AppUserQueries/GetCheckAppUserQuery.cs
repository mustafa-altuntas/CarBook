﻿using CarBook.Aplication.Features.Mediator.Results.AppUserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.AppUserQueries
{
    public class GetCheckAppUserQuery:IRequest<GetCheckAppUserQueryResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
