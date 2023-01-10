using ECommerce.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.ViewModels
{
    public class CreateNewProductViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter product Name")]
        public string? ProName { get; set; }

        [Required(ErrorMessage = "Enter product Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Enter product Price")]
        public decimal Price { get; set; }

        public string ProImage { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }

        public int CatId { get; set; }
        [ForeignKey("CatId")]

        public IEnumerable<Category> category { get; set; }
    }
}
