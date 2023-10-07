using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    public static class ProductManager
    {
        private static List<Product> products = new List<Product>();

        public static List<Product> GetAllProducts()
        {
            return products;
        }

        public static Product GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        public static void AddProduct(Product product)
        {
            product.Id = GenerateProductId();
            products.Add(product);
        }

        public static void UpdateProduct(Product updatedProduct)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.CategoryIds = updatedProduct.CategoryIds;
            }
        }

        public static void DeleteProduct(int id)
        {
            var productToRemove = products.FirstOrDefault(p => p.Id == id);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
            }
        }

        private static int GenerateProductId()
        {
            var random = new Random();
            int newId;
            do
            {
                newId = random.Next(1, 10000);
            } while (products.Any(p => p.Id == newId));
            return newId;
        }

        public static void UpdateProductCategoryAssociations(int categoryId)
        {
            foreach (var product in products)
            {
                // Remove the category ID from the product's CategoryIds list
                product.CategoryIds.Remove(categoryId);
            }
        }

    }
}
