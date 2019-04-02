using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopping.Service;
using Shopping.Service.Commands;
using Shopping.Web.Models;

namespace Shopping.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ICommandHandler<SearchAdvertisements> searchAdvertisementsService;
        private  ICommandHandler<SearchCountrys> searchCountrysService;
        private ICommandHandler<SearchSlides> searchSlidesService;
        private ICommandHandler<SearchProducts> searchProductsService;

        public HomeController(ICommandHandler<SearchProducts> searchProductsService, ICommandHandler<SearchAdvertisements> searchAdvertisementsService, ICommandHandler<SearchSlides> searchSlidesService,ICommandHandler<SearchCountrys> searchCountrysService,ICommandHandler<SearchProductCategories> SearchProductCategoriesService) : base(SearchProductCategoriesService)
        {
            this.searchCountrysService = searchCountrysService;
            this.searchSlidesService = searchSlidesService;
            this.searchAdvertisementsService = searchAdvertisementsService;
            this.searchProductsService = searchProductsService;
        }
        public async Task<IActionResult> Index()
        {
            //    var searchCountrys = new SearchCountrys();
            //    searchCountrys.Name = "G";
            //    Result result = await searchCountrysService.HandleAsync(searchCountrys);
            var searchSlides = new SearchSlides();
            Result result = await searchSlidesService.HandleAsync(searchSlides);
            ViewBag.Slides = result.Value;

            var searchAdvertisements = new SearchAdvertisements();
            Result result1 = await searchAdvertisementsService.HandleAsync(searchAdvertisements);
            ViewBag.Banners = result1.Value;

            var searchProducts = new SearchProducts();
            searchProducts.IsFeatured = true;
            Result result2 = await searchProductsService.HandleAsync(searchProducts);
            ViewBag.Products = result2.Value;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
