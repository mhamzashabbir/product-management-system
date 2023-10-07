using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class CategoryDetailsViewModel
    {
        public Category Category { get; set; }
        public List<Product> AssociatedProducts { get; set; }
    }
}
