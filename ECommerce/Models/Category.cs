using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }

        [Required (ErrorMessage ="Category Name is Required")]
        public string? CatName { get; set; }

        [Required(ErrorMessage ="Category Name is Required")]
        public string? CatPhoto { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }

        public virtual ICollection<Product> products { get; set; }
    }
}
