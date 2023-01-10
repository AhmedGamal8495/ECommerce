using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class ShoppingCart
    {
        [Key]
        public int CartId { get; set; }

        public int ProId { get; set; }
        [ForeignKey("ProId")]
        public virtual Product products { get; set; }

        [Range(1,int.MaxValue,ErrorMessage ="Amount must be more than 1")]
        public int Qty { get; set; }

        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
