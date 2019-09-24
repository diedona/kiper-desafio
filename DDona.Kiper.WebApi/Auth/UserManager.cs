using System.Linq;
using System.Security.Claims;

namespace DDona.Kiper.WebApi.Auth
{
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Retrieves username based on token
        /// </summary>
        /// <param name="claimsManager"></param>
        /// <returns></returns>
        public static string GetUsername(this ClaimsPrincipal claimsManager)
        {
            return claimsManager.Identity.Name;
        }

        public static string GetRole(this ClaimsPrincipal claimsManager)
        {
            var claim = GetClaim(claimsManager, ClaimTypes.Role);
            if(claim == null)
            {
                return string.Empty;
            }
            else
            {
                return claim.Value;
            }
        }

        private static Claim GetClaim(ClaimsPrincipal claimsManager, string claimId)
        {
            return claimsManager.Claims.FirstOrDefault(x => x.Type.Equals(claimId));
        }
    }
}
