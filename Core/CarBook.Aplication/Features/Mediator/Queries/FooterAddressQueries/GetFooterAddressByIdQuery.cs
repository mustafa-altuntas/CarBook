﻿using CarBook.Aplication.Features.Mediator.Results.FooterAddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery:IRequest<GetFooterAddressByIdQueryResult>
    {
        public int FooterAddressId { get; set; }

        public GetFooterAddressByIdQuery(int footerAddressId)
        {
            FooterAddressId = footerAddressId;
        }
    }
}
