using Microsoft.AspNetCore.Identity;


namespace WebApi.Modules.User.Domain.Entites
{
    public class UserIdentity : IdentityUser
    {
        public string? Name { get; set; }
        public bool IsLockedOut { get; set; }

    }
}
