using System.Security.Claims;
using FitnessApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace GymApp.Customizations.Identity
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<AspNetUser>
    {
        public CustomClaimsPrincipalFactory(UserManager<AspNetUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AspNetUser user)
        {
            ClaimsIdentity identity =  await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Id", user.Id));
            identity.AddClaim(new Claim("FullName", user.FullName));
            // identity.AddClaim(new Claim("Username", user.UserName));
            return identity;
;        }
    }
}