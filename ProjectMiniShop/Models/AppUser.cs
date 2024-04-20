using Microsoft.AspNetCore.Identity;

namespace ProjectMiniShop.Models
{
    public class AppUser:IdentityUser
    {
        public string? Address{ get; set; }
    }
}
