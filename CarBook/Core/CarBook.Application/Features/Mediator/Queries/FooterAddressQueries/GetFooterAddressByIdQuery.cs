﻿using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery : IRequest<GetFooterAddressByIdQueryResults>
    {
        public GetFooterAddressByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
