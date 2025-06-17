using Microsoft.Data.SqlClient;
using retail_store_inventory_2.Models;
using retail_store_inventory_2.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using retail_store_inventory_2.Data;
using System.Linq;

namespace retail_store_inventory_2.Models.Repositories
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly InventoryContext _context;

        // Constructor to inject InventoryContext
        public ProductCommandRepository(InventoryContext context)
        {
            _context = context;
        }

        public void AddProduct(ProductModel product)
        {
            product.ProductCreationDate = DateTime.Now;
            _context.Products.Add(product);
            _context.SaveChanges();
        }


        public void UpdateProduct(ProductModel updatedProduct)
        {
            ProductModel existing = _context.Products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (existing != null)
            {
                existing.Name = updatedProduct.Name;
                existing.Category = updatedProduct.Category;
                existing.Quantity = updatedProduct.Quantity;
                existing.Price = updatedProduct.Price;

                _context.SaveChanges();  
            }
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
