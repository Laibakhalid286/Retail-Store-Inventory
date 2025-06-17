using retail_store_inventory_2.Data;

namespace retail_store_inventory_2.Models.Repositories
{
    public class StockRepository:IStockRepository
    {
        private readonly InventoryContext _context;

        public StockRepository(InventoryContext context)
        {
            _context = context;
        }

        public List<ProductModel> GetTotalStockReport(DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Products.AsQueryable();

            if (startDate.HasValue)
                query = query.Where(p => p.ProductCreationDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(p => p.ProductCreationDate <= endDate.Value);

            return query.ToList();
        }

        public List<ProductModel> GetLowStockProducts(int threshold, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Products
                .Where(p => p.Quantity < threshold);

            if (startDate.HasValue)
            {
                query = query.Where(p => p.ProductCreationDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(p => p.ProductCreationDate <= endDate.Value);
            }

            return query.ToList();
        }

    }
}
