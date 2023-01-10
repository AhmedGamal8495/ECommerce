using ECommerce.Data;
using ECommerce.Models;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ECommerceDbContext _context;

        public HomeController(ILogger<HomeController> logger,ECommerceDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var vm = new IndexViewModel()
            {
                categories = _context.categories.ToList(),
                products = _context.products.Take(6).ToList()
            };
            return View(vm);
        }
        public async Task<List<Product>> getpage(IQueryable<Product> result , int pagenumber)
        {
            const int pagesize = 6;
            decimal rowCount =await _context.products.CountAsync();
            var pagecount = Math.Ceiling(rowCount/pagesize);
            if (pagenumber > pagecount)
            {
                pagenumber = 1;
            }
            pagenumber = pagenumber <= 0 ? 1 : pagenumber;
            int skipcount = (pagenumber - 1) * pagesize;
            var pageData = await result.Skip(skipcount).Take(pagesize).ToListAsync();

            ViewBag.currentpage = pagenumber;
            ViewBag.pagecount = pagecount;

            return pageData;

        }
        public async Task<IActionResult> Product(int page=1)
        {
            var products =  _context.products;
            var model = await getpage(products, page);
            return View(model);
        }
        
        public IActionResult ProductDetails(int? id)
        {
            var product = _context.products.Include(c=>c.category).FirstOrDefault(x => x.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult SearchProduct(string name)
        {
            //name = name.ToLower();
            var products = _context.products.Where(p=>p.ProName.Contains(name)).ToList();
            return View(products);
        }

        public IActionResult CategoryProduct(int id)
        {
            var products = _context.products.Where(c=>c.CatId == id).ToList();
            return View(products);
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}