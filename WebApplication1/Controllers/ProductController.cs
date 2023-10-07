using System;
using System.Collections.Generic;
using System.Linq; // Add this using directive to resolve the issue
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = ProductManager.GetAllProducts();
            return View(products);
        }

        public IActionResult Create()
        {
            // Get the list of available categories
            var categories = CategoryManager.GetAllCategories();

            // Store the categories in ViewBag
            ViewBag.Categories = categories;

            return View();
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductManager.AddProduct(product);
                foreach (var categoryId in product.CategoryIds)
                {
                    var category = CategoryManager.GetCategoryById(categoryId);
                    if (category != null)
                    {
                        category.AddProductId(product.Id);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            Product product = ProductManager.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            // Initialize CategoryIds if it's null
            product.CategoryIds ??= new List<int>();

            // Get the associated category names for the product
            var categoryNames = CategoryManager.GetAllCategories()
                .Select(category => new { Id = category.Id, Name = category.Name })
                .ToList();

            // Pass the category names to the Edit view
            ViewBag.CategoryNames = categoryNames;

            return View(product);
        }




        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductManager.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Details(int id)
        {
            Product product = ProductManager.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            Product product = ProductManager.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            ProductManager.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
