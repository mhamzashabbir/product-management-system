using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "The Price field must be a positive number.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please select at least one category.")]
        public List<int> CategoryIds { get; set; }

        // Add a parameterless constructor
        public Product()
        {
            // You can initialize any properties with default values here if needed.
        }

        public Product(int id, string name, string description, decimal price, List<int> categoryIds)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryIds = categoryIds;
        }
    }
}
