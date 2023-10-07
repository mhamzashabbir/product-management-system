using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            List<Category> categories = CategoryManager.GetAllCategories();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoryManager.AddCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            Category category = CategoryManager.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            // Pass the category data to the view
            return View(category);
        }



        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoryManager.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Details(int id)
        {
            var category = CategoryManager.GetCategoryById(id);

            if (category == null)
            {
                return NotFound(); // Return a 404 response if the category is not found
            }


            var productsInCategory = new List<Product>();

            var productIds = category.ProductIds;

            // Retrieve the actual products associated with these IDs
            productsInCategory = ProductManager.GetAllProducts().Where(p => productIds.Contains(p.Id)).ToList();

            // Pass the products to the view
            return View(productsInCategory);
        }



        public IActionResult Delete(int id)
        {
            Category category = CategoryManager.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Update product associations
            ProductManager.UpdateProductCategoryAssociations(id);

            // Delete the category
            CategoryManager.DeleteCategory(id);
            return RedirectToAction("Index");
        }



    }
}
