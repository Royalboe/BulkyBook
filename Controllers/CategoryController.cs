using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Data;
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Data.ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent cross site request forgery. It uses a key from the view to validate 
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder can not match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var categoryFromDb = _db.Categories.Find(id);
            // var categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id==id);
            // var categoryFromDb = _db.Categories.SingleOrDefault(u => u.Id==id);
            if (categoryFromDb == null)
                return NotFound();
            return View(categoryFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken] // Prevent cross site request forgery. It uses a key from the view to validate 
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder can not match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var categoryFromDb = _db.Categories.Find(id);
            // var categoryFromDb = _db.Categories.FirstOrDefault(u => u.Id==id);
            // var categoryFromDb = _db.Categories.SingleOrDefault(u => u.Id==id);
            if (categoryFromDb == null)
                return NotFound();
            return View(categoryFromDb);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // Prevent cross site request forgery. It uses a key from the view to validate 
        public IActionResult Delete(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder can not match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
