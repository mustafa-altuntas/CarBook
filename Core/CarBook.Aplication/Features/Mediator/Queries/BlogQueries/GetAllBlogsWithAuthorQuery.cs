﻿using CarBook.Aplication.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.BlogQueries
{
    public class GetAllBlogsWithAuthorQuery:IRequest<List<GetAllBlogsWithAuthorQueryResult>>
    {
    }
}