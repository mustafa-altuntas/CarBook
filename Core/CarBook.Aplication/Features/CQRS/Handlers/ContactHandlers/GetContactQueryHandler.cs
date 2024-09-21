using CarBook.Aplication.Features.CQRS.Results.ContactResults;
using CarBook.Aplication.Interfaces;
using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handler()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(c => new GetContactQueryResult
            {
                ContactId = c.ContactId,
                Email = c.Email,
                Message = c.Message,
                Name = c.Name,
                SendDate = c.SendDate,
                Subject = c.Subject
            }).ToList();
        }
    }
}
