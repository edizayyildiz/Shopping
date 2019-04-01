using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopping.Service;
using Shopping.Service.Commands;
using Shopping.Service.Queries;

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
        public IActionResult ProductsGrid()
        {
            return View();
        }
        public async Task<IActionResult> ProductsList()
        {
            var searchProduct = new SearchProducts();
            Result result = await searchProductsService.HandleAsync(searchProduct);
            return View(result.Value);
        }
        public IActionResult ProductsDetails()
        {
            return View();
        }
    }
}