using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    public static class CategoryManager
    {
        private static List<Category> categories = new List<Category>();

        public static List<Category> GetAllCategories()
        {
            return categories;
        }

        public static Category GetCategoryById(int id)
        {
            return categories.FirstOrDefault(c => c.Id == id);
        }

        public static void AddCategory(Category category)
        {
            category.Id = GenerateCategoryId();
            categories.Add(category);
        }

        public static void UpdateCategory(Category updatedCategory)
        {
            var existingCategory = categories.FirstOrDefault(c => c.Id == updatedCategory.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = updatedCategory.Name;
                existingCategory.ProductIds = updatedCategory.ProductIds;
            }
        }

        public static void DeleteCategory(int id)
        {
            var categoryToRemove = categories.FirstOrDefault(c => c.Id == id);
            if (categoryToRemove != null)
            {
                categories.Remove(categoryToRemove);
            }
        }

        private static int GenerateCategoryId()
        {
            var random = new Random();
            int newId;
            do
            {
                newId = random.Next(1, 10000);
            } while (categories.Any(c => c.Id == newId));
            return newId;
        }
    }
}
