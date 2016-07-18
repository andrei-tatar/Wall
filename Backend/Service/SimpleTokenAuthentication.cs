using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using Service.Services;

namespace Service
{
    public class SimpleTokenAuthentication : IAuthenticationFilter
    {
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var authorization = context.Request.Headers.Authorization;
            if (authorization == null) return;

            if (authorization.Scheme != "Bearer") return;

            var token = authorization.Parameter;
            if (string.IsNullOrWhiteSpace(token)) return;

            var userName = Util.TokenToUser(token);
            var user = await ServiceProvider.Instance.UserRepository.Get(userName);
            if (user == null) return;

            context.Principal = new GenericPrincipal(new GenericIdentity(user.Id), user.Roles);
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            context.Result = new ResponseMessageResult(await context.Result.ExecuteAsync(cancellationToken));
        }
    }
}