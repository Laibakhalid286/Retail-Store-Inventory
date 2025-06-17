namespace retail_store_inventory_2.Models
{
    public class StockModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int RemainingStock { get; set; }
        public decimal TotalStockValue { get; set; }
    }
}
