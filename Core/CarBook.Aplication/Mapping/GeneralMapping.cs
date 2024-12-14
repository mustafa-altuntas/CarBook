using AutoMapper;
using CarBook.Aplication.Features.Mediator.Results.ReservationResults;
using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Reservation,GetReservationQueryResult>().ReverseMap();
        }
    }
}
