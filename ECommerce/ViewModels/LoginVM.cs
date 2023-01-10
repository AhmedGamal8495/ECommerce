using System.ComponentModel.DataAnnotations;

namespace ECommerce.ViewModels
{
    public class LoginVM
    {
        [EmailAddress]
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
