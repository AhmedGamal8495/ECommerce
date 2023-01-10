using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class HomeController : Controller
    {
        private readonly ECommerceDbContext _context;
        public HomeController(ECommerceDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowMessage()
        {
            var messages = _context.contacts.ToList();
            return View(messages);
        }
    }
}
