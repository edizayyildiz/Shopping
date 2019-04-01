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
        private ICommandHandler<SearchCountrys> searchCountrysService;
        public HomeController(ICommandHandler<SearchCountrys> searchCountrysService,ICommandHandler<SearchProductCategories> SearchProductCategoriesService) : base(SearchProductCategoriesService)
        {
            this.searchCountrysService = searchCountrysService;
        }
        public async Task<IActionResult> Index()
        {
            var searchCountrys = new SearchCountrys();
            searchCountrys.Name = "G";
            Result result = await searchCountrysService.HandleAsync(searchCountrys);
            return View(result.Value);
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
