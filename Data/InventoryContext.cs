using Microsoft.EntityFrameworkCore;
using retail_store_inventory_2.Models;

namespace retail_store_inventory_2.Data
{
    public class InventoryContext:DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }

        public DbSet<ProductModel> Products { get; set; }
    }
}
