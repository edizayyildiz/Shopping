using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Model.Entities;
using Shopping.Service;
using Shopping.Service.Commands;

namespace Shopping.Web.Controllers
{
    public class ShopController : Controller
    {
        private ICommandHandler<SearchCountrys> searchCountrysService;
        private ICommandHandler<SearchCitys> searchCitysService;

        public ShopController(ICommandHandler<SearchCountrys> searchCountrysService, ICommandHandler<SearchCitys> searchCitysService)
        {
            this.searchCountrysService = searchCountrysService;
            this.searchCitysService = searchCitysService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Checkout()
        {
            var searchCountries = new SearchCountrys();
            var searchCities = new SearchCitys();
            var address = new Address();
            Result resultCountry = await searchCountrysService.HandleAsync(searchCountries);
            Result resultCity = await searchCitysService.HandleAsync(searchCities);
            ViewBag.Countries = new SelectList(resultCountry.Value, "Id", "Name", address.CountryId);
            ViewBag.Cities = new SelectList(resultCity.Value, "Id", "Name", address.CityId);
            return View();
        }
    }
}