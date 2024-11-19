﻿
using System.Net.Http.Headers;

namespace CarBook.WebUI.Handlers
{
    public class TokenHandler:DelegatingHandler
    {


        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            
            var token = _httpContextAccessor.HttpContext?.User?.Claims
                            .FirstOrDefault(c => c.Type == "carbooktoken")?.Value;

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }


    }
}
