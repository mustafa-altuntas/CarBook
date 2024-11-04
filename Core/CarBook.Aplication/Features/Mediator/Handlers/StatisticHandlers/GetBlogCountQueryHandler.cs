﻿using CarBook.Aplication.Features.Mediator.Queries.StatisticQueries;
using CarBook.Aplication.Features.Mediator.Results.StatisticResults;
using CarBook.Aplication.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CarBook.Aplication.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetBlogCountQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBlogCount();
            return new GetBlogCountQueryResult
            {
                BlogCount = value
            };
        }
    }
}
