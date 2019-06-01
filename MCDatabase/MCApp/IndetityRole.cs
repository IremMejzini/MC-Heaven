using Microsoft.AspNetCore.Identity;

namespace MCApp
{
    internal class IndetityRole : IdentityRole
    {
        public IndetityRole(string roleName) : base(roleName)
        {
        }
    }
}