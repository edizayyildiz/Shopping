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
        public ShopController(ICommandHandler<SearchProductCategories> SearchProductCategoriesService, ICommandHandler<SearchProducts> searchProductsService) : base(SearchProductCategoriesService)
        {
            this.searchProductsService = searchProductsService;
        }
        public IActionResult Index()
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
        public IActionResult ProductsList()
        {
           
            return View();
        }
        public IActionResult ProductsDetails()
        {
            return View();
        }
    }
}