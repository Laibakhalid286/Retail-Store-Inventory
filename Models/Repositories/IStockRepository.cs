namespace retail_store_inventory_2.Models.Repositories
{
    public interface IStockRepository
    {
        List<ProductModel> GetLowStockProducts(int threshold, DateTime? startDate, DateTime? endDate);
        List<ProductModel> GetTotalStockReport(DateTime? startDate, DateTime? endDate);
    }
}
