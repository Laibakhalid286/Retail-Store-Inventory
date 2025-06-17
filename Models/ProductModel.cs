using Microsoft.EntityFrameworkCore;

namespace retail_store_inventory_2.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public DateTime ProductCreationDate { get; set; }
    }
}
