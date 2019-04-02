using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopping.Service;
using Shopping.Service.Commands;

namespace Shopping.Web.Controllers
{
    public class ShopController : BaseController
    {
        private ICommandHandler<SearchProducts> searchProductsService;
        public ShopController(ICommandHandler<SearchProducts> searchProductsService, ICommandHandler<SearchProductCategories> SearchProductCategoriesService) : base(SearchProductCategoriesService)
        {
            this.searchProductsService = searchProductsService;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Stores()
        {
            return View();
        }
        public async Task<IActionResult> ProductsGrid()
        { 
            var searchProducts = new SearchProducts();          
            //searchProducts.SortField = "name";           
            Result result = await searchProductsService.HandleAsync(searchProducts);
            return View(result.Value);
        }
        public async Task<IActionResult> ProductsList()
        {
            var searchProduct = new SearchProducts();
            searchProduct.IsPagedSearch = true;
            Result result = await searchProductsService.HandleAsync(searchProduct);

            return View(result.Value);
        }
        public IActionResult ProductsDetails()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}