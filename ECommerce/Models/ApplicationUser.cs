using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
    }
}
