using ECommerce.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly ECommerceDbContext _context;
        public CategoryController(ECommerceDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(Category model , IFormFile file)
        {
            
            if (file != null)
            { 
                string imagename = Guid.NewGuid().ToString() + ".jpg";
                string filePathImg = Path.Combine(Directory.GetCurrentDirectory(),@"wwwroot\category",imagename);
                using (var stream = System.IO.File.Create(filePathImg))
                {
                    await file.CopyToAsync(stream);
                }
                model.CatPhoto = imagename;
            }
            _context.Add(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var category = _context.categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public async Task <IActionResult> Edit(int? id,Category model ,IFormFile file)
        {

            if (file != null)
            {
                string imagename = Guid.NewGuid().ToString() + ".jpg";
                string filePathImg = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\category", imagename);
                using (var stream = System.IO.File.Create(filePathImg))
                {
                    await file.CopyToAsync(stream);
                }
                model.CatPhoto = imagename;
            }
            else {
                model.CatPhoto = model.CatPhoto;
            }
            _context.Update(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var category = _context.categories.Find(id);
                _context.Remove(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
       
    }
}
