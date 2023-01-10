using ECommerce.Data;
using ECommerce.Models;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ECommerceDbContext _context;
        public ProductsController(ECommerceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.products.Include(c => c.category).ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewData["categoryname"] = new SelectList(_context.categories, "CatId", "CatName");

            //viewmodelلو عايز استخدم طريقه ال 

            //var vmodel = new CreateNewProductViewModel()
            //{
            //    category = _context.categories.ToList()
            //};

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product model, IFormFile file)
        {

            if (file != null)
            {
                string imagename = Guid.NewGuid().ToString() + ".jpg";
                string filePathImg = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\product", imagename);
                using (var stream = System.IO.File.Create(filePathImg))
                {
                    await file.CopyToAsync(stream);
                }
                model.ProImage = imagename;
            }
            _context.Add(model);
            _context.SaveChanges();
            ViewData["categoryname"] = new SelectList(_context.categories, "CatId", "CatName");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var product = await _context.products.FindAsync(id);
            ViewData["categoryname"] = new SelectList(_context.categories, "CatId", "CatName");
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id,Product model, IFormFile file)
        {

            if (file != null)
            {
                string imagename = Guid.NewGuid().ToString() + ".jpg";
                string filePathImg = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\product", imagename);
                using (var stream = System.IO.File.Create(filePathImg))
                {
                    await file.CopyToAsync(stream);
                }
                model.ProImage = imagename;
            }
            else 
            {
                model.ProImage = model.ProImage;
            }
            _context.Update(model);
            _context.SaveChanges();
            ViewData["categoryname"] = new SelectList(_context.categories, "CatId", "CatName");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var product = await _context.products.FindAsync(id);
            _context.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
