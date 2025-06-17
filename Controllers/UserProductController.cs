using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using retail_store_inventory_2.Models;
using retail_store_inventory_2.Models.Repositories;

namespace retail_store_inventory_2.Controllers
{
    [Authorize]
    public class UserProductController : Controller
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IProductQueryRepository _productQueryRepository;

        public UserProductController(IProductCommandRepository productCommandRepository, IProductQueryRepository productQueryRepository)
        {
            _productCommandRepository = productCommandRepository;
            _productQueryRepository = productQueryRepository;
        }

        [Authorize(Policy = "UserOnly")]
        public IActionResult UserSearch()
        {
            return View();
        }

        [Authorize(Policy = "UserOnly")]
        public IActionResult SearchResult(string name, string category, int? minPrice, int? maxPrice)
        {
            var products = _productQueryRepository.SearchProducts(name, category, minPrice, maxPrice);

            if (products.Count == 0)
            {
                TempData["ErrorMessage"] = "No products found matching your search.";
            }

            return View("~/Views/Product/SearchResult.cshtml",products);
        }

        [Authorize(Policy = "UserOnly")]
        public IActionResult UserDisplay()
        {
            List<ProductModel> products = _productQueryRepository.GetAllProducts();

            return View(products);
        }
    }
}
