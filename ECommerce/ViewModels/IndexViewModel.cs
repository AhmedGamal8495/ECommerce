using ECommerce.Models;

namespace ECommerce.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Category> categories { get; set; }

        public IEnumerable<Product> products { get; set; }

    }
}
