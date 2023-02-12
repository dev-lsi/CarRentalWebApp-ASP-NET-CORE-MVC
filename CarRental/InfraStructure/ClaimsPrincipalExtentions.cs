using System.Security.Claims;

namespace CarRental.InfraStructure
{
    public static class ClaimsPrincipalExtentions
    {
        public static string GetId(this ClaimsPrincipal user)=>
            user.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
