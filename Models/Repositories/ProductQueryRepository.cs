using Microsoft.EntityFrameworkCore;
using retail_store_inventory_2.Data;

namespace retail_store_inventory_2.Models.Repositories
{
    public class ProductQueryRepository:IProductQueryRepository
    {
        private readonly InventoryContext _context;

        // Constructor to inject InventoryContext
        public ProductQueryRepository(InventoryContext context)
        {
            _context = context;
        }
        public List<ProductModel> SearchProducts(string name, string category, int? minPrice, int? maxPrice)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.Contains(name));

            if (!string.IsNullOrEmpty(category) && category != "All Categories")
                query = query.Where(p => p.Category == category);

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice);

            return query.ToList();
        }

        public ProductModel GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<ProductModel> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}
