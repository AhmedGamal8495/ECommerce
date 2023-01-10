using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ECommerceDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ECommerceDbContext context , UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Cart()
        {
            var user = await _userManager.GetUserAsync(User);
            var result = _context.shoppingCarts.Include(p => p.products).Where(u=>u.UserId == user.Id).ToList();

            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddToCart(ShoppingCart model,int qty)
        {
            var product = _context.products.FirstOrDefault(p=>p.Id == model.ProId);
            var user = await _userManager.GetUserAsync(User);

            var cart = new ShoppingCart
            {
                UserId = user.Id,
                ProId = product.Id ,
                Qty = qty,
            };

            var shopcart = _context.shoppingCarts.FirstOrDefault(u=>u.UserId==user.Id && u.ProId==model.ProId);

            if (qty <= 0)
            { 
                qty = 1;
            }

            if (shopcart == null)
                _context.shoppingCarts.Add(cart);
            else
                shopcart.Qty += model.Qty;
            

            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }


        [HttpPost]
        public async Task<IActionResult> RemoveItem(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            var shopcart = _context.shoppingCarts.FirstOrDefault(u => u.UserId == user.Id && u.CartId == id);

            

            if (shopcart != null)
                _context.shoppingCarts.Remove(shopcart);
          

            _context.SaveChanges();
            return RedirectToAction(nameof(Cart));
        }

    }
}
