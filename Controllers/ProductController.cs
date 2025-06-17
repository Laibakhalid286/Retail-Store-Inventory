using Microsoft.AspNetCore.Mvc;
using retail_store_inventory_2.Models.Repositories;
using retail_store_inventory_2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using retail_store_inventory_2.Hubs;

namespace retail_store_inventory_2.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IStockRepository _productStockRepository;
        private readonly IHubContext<NotificationHub> _hubContext;
        public ProductController(IProductCommandRepository productCommandRepository, IHubContext<NotificationHub> hubContext, IProductQueryRepository productQueryRepository, IStockRepository productStockRepository)
        {
            
            _productCommandRepository =  productCommandRepository;
            _productQueryRepository = productQueryRepository;
            _productStockRepository = productStockRepository;
            _hubContext = hubContext;
        }

        [Authorize(Policy = "CanManageProducts")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Policy = "CanManageProducts")]
        [HttpPost]
        public async Task<IActionResult> Add(string name, int quantity, int price, string category)
        {
            ProductModel product = new ProductModel
            {
                Name = name,
                Quantity = quantity,
                Price = price,
                Category = category
            };

            _productCommandRepository.AddProduct(product);
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", "Product list has been updated by admin.");

            TempData["SuccessMessage"] = "Product has been added successfully!";
            return RedirectToAction("Display");
        }

        [Authorize(Policy = "CanManageProducts")]
        [HttpGet]
        public IActionResult UpdateSearch()
        {
            return View();
        }

        [Authorize(Policy = "CanManageProducts")]
        [HttpPost]
        public IActionResult Update(int id)
        {
            ProductModel product = _productQueryRepository.GetProductById(id);
            if (product == null)
            {
                ViewBag.Message = "Product not found!";
                return View("UpdateSearch");
            }
            return View("Update", product); 
        }

        [Authorize(Policy = "CanManageProducts")]
        [HttpPost]
        public async Task<IActionResult> UpdateConfirmed(ProductModel model)
        {
            _productCommandRepository.UpdateProduct(model);

            await _hubContext.Clients.All.SendAsync("ReceiveNotification", " Product list has been updated by admin.");

            ViewBag.Message = "Product updated successfully!";

            return View("Display", model);
        }

        [Authorize(Policy = "CanManageProducts")]
        [HttpGet]
        public IActionResult DeleteSearch()
        {
            return View();
        }

        [Authorize(Policy = "CanManageProducts")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            ProductModel product = _productQueryRepository.GetProductById(id);
            if (product == null)
            {
                ViewBag.Message = "Product not found!";
                return View("DeleteSearch");
            }
            return View("Delete", product);
        }

        [Authorize(Policy = "CanManageProducts")]
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(ProductModel model)
        {
            _productCommandRepository.DeleteProduct(model.Id);
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", "Product list has been updated by admin.");
            ViewBag.Message = "Product deleted successfully!";
             return View("Display", model);
        }

        [Authorize(Policy = "CanManageProducts")]
        public IActionResult Search()
        {
            return View();
        }


        [Authorize(Policy = "CanViewProducts")]
        public IActionResult SearchResult(string name, string category, int? minPrice, int? maxPrice)
        {
            List<ProductModel> products = _productQueryRepository.SearchProducts(name, category, minPrice, maxPrice);

            if (products.Count == 0)
            {
                TempData["ErrorMessage"] = "No products found matching your search.";
            }

            return View(products);
        }

        [Authorize(Policy = "CanManageProducts")]
        public IActionResult Display()
        {
            List<ProductModel> products = _productQueryRepository.GetAllProducts();

            return View(products);
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult Reports()
        {
            return View();
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult TotalStock(DateTime? startDate, DateTime? endDate)
        {
            var totalStockProducts = _productStockRepository.GetTotalStockReport(startDate, endDate);

            var reportData = totalStockProducts.Select(p => new StockModel
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Quantity = p.Quantity,
                Price = p.Price,
                RemainingStock = p.Quantity,
                TotalStockValue = p.Quantity * p.Price
            }).ToList();

            return View(reportData);
        }

        [Authorize(Policy = "AdminOnly")]
        public IActionResult LowStock(DateTime? startDate, DateTime? endDate)
        {
            int threshold = 50; 

            var lowStockProducts = _productStockRepository.GetLowStockProducts(threshold, startDate, endDate);
            return View(lowStockProducts);
        }

    }
}
