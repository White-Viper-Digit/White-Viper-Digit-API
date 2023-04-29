using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace White.Viper.Digit.Api.Security
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirements>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            HasScopeRequirements requirement)
        {
            // If user does not have the scope claim, get out of here.

            if(!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;

            // Split the scopes string into an array
            var scope = context.User
                .FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer);
                if (scope != null)
                {
                var scopes = scope.Value.Split(' ');

                

            // Succeed if the scope array contains the required scope
            if(scopes.Any(s => s == requirement.Scope))
                context.Succeed(requirement);
                }

            return Task.CompletedTask;
        }
    }
}