using System.Security.Claims;
using FitnessApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace GymApp.Customizations.Identity
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public CustomClaimsPrincipalFactory(UserManager<ApplicationUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            ClaimsIdentity identity =  await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Id", user.Id));
            identity.AddClaim(new Claim("FullName", user.FullName));
            // identity.AddClaim(new Claim("Username", user.UserName));
            return identity;
;        }
    }
}