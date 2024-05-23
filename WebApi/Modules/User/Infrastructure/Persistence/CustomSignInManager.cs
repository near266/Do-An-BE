using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using WebApi.Modules.User.Domain.Entites;

namespace WebApi.Modules.User.Infrastructure.Persistence
{
    public class CustomSignInManager : SignInManager<UserIdentity>
    {
        public CustomSignInManager(UserManager<UserIdentity> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<UserIdentity> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<UserIdentity>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<UserIdentity> confirmation)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
        }

        public override async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            var user = await UserManager.FindByNameAsync(userName);
            if (user != null && user.IsLockedOut)
            {
                return SignInResult.LockedOut;
            }

            return await base.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }
    }

}
