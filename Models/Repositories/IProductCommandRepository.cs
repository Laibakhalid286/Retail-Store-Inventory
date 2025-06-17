namespace retail_store_inventory_2.Models.Repositories
{
    public interface IProductCommandRepository
    {
        public void AddProduct(ProductModel product);

        public void UpdateProduct(ProductModel product);

        public void DeleteProduct(int id);


    }
}
