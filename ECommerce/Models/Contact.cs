using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
