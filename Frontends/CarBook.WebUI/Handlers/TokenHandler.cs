
using System.Net.Http.Headers;

namespace CarBook.WebUI.Handlers
{
    public class TokenHandler:DelegatingHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenHandler(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "CarBookJwtCookie")?.Value;

            if(string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization  = new AuthenticationHeaderValue("Bearer",token);
            }

            return base.SendAsync(request, cancellationToken);
        }

    }
}
