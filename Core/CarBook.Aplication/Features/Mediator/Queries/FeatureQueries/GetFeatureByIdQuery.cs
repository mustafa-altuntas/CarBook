﻿using CarBook.Aplication.Features.Mediator.Results.FeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery : IRequest<GetFeatureByIdQueryResult>
    {
        public int FeatureId { get; set; }

        public GetFeatureByIdQuery(int featureId)
        {
            FeatureId = featureId;
        }
    }
}
