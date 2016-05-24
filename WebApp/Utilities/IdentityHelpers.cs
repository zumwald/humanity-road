using System.Security.Claims;

namespace WebApp.Utilities
{
    public static class IdentityHelpers
    {
        public const string IMAGE_URI_K = "imageUri";
        public const string PERSON_ID_K = "humanityRoadIdentifier";
        public const string PERSON_FIRSTNAME_K = "firstName";
        public const string PERSON_LASTNAME_K = "lastName";
        public const string PERSON_PRIMARY_EMAIL_K = "primaryEmail";

        public static string GetPersonId(this ClaimsPrincipal claim)
        {
            return claim.FindFirst(PERSON_ID_K).Value;
        }

        public static string GetDisplayImage(this ClaimsPrincipal claim)
        {
            return claim.FindFirst(IMAGE_URI_K)?.Value ?? string.Empty;
        }

        public static string GetUserProperty(this ClaimsPrincipal c, string key)
        {
            return c.FindFirst(key)?.Value ?? string.Empty;
        }
    }
}
