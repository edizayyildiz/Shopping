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
    public class HomeController : Controller
    {
        private ICommandHandler<AddCountry> addCountryService;
        public HomeController(ICommandHandler<AddCountry> addCountryService)
        {
            this.addCountryService = addCountryService;
        }
        public async Task<IActionResult> Index()
        {
            var addCountry = new AddCountry();
            addCountry.Name = "Türkiye";
            await addCountryService.HandleAsync(addCountry);
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
