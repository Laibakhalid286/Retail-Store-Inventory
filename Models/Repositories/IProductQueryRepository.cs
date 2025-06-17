namespace retail_store_inventory_2.Models.Repositories
{
    public interface IProductQueryRepository
    {
        public List<ProductModel> SearchProducts(string name, string category, int? minPrice, int? maxPrice);

        public ProductModel GetProductById(int id);

        public List<ProductModel> GetAllProducts();
    }
}
