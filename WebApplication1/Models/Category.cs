using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> ProductIds { get; set; } = new List<int>();

        public Category()
        {
            ProductIds = new List<int>();
        }

        public Category(int id, string name, List<int> productIds)
        {
            Id = id;
            Name = name;
            ProductIds = productIds;
        }
        
        public void AddProductId(int productId)
        {
            ProductIds.Add(productId);
        }
}
}
