using CarBook.Aplication.Features.Mediator.Queries.AppUserQueries;
using CarBook.Aplication.Features.Mediator.Results.AppUserResults;
using CarBook.Aplication.Interfaces;
using CarBook.Aplication.Interfaces.AppUserInterfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Aplication.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IAppUserRepository _appUserRepository;

        public GetCheckAppUserQueryHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var valueResult = new GetCheckAppUserQueryResult();
            var user = await _appUserRepository.GetByFilterAsync(x=>x.UserName==request.UserName && x.Password==request.Password);
            if (user == null)
            {
                valueResult.IsExist = false;
            }
            else
            {
                valueResult.IsExist = true;
                valueResult.UserName = user.UserName;
                valueResult.Role = user.AppRole.AppRoleName;
                valueResult.Id = user.AppUserId;
            }
            return valueResult;
        }
    }
}
