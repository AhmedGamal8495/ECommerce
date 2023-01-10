using ECommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class ECommerceDbContext : IdentityDbContext<ApplicationUser>
    {
        public ECommerceDbContext( DbContextOptions<ECommerceDbContext> options):base(options)
        {
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
    }
}
