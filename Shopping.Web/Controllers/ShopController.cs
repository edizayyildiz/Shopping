using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Model.Entities;
using Shopping.Service;
using Shopping.Service.Commands;
using Shopping.Service.Queries;
using Shopping.Service.Queries.Commerce;

namespace Shopping.Web.Controllers
{
    public class ShopController : BaseController
    {
        private ICommandHandler<SearchProducts> searchProductsService;
        private ICommandHandler<SearchCitys> searchCitiesService;
        private ICommandHandler<SearchCountrys> searchCountriesService;
        private readonly ICommandHandler<SearchCarts> searchCartService;
        private readonly ICommandHandler<GetCart> getCartService;

        public ShopController(ICommandHandler<SearchCountrys> searchCountriesService, ICommandHandler<SearchCitys> searchCitiesService, ICommandHandler<SearchProducts> searchProductsService, ICommandHandler<SearchProductCategories> SearchProductCategoriesService, ICommandHandler<SearchCarts> searchCartService, ICommandHandler<GetCart> getCartService) : base(SearchProductCategoriesService)
        {
            this.searchProductsService = searchProductsService;
            this.searchCitiesService = searchCitiesService;
            this.searchCountriesService = searchCountriesService;
            this.searchCartService = searchCartService;
            this.getCartService = getCartService;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Stores()
        {
            return View();
        }

        public async Task<IActionResult> Products(SearchProducts searchProducts)
        {

            Result result = await searchProductsService.HandleAsync(searchProducts);
            return View(result.Value);
        }
        public async Task<IActionResult> ProductsList(SearchProducts searchProducts)
        {
            ViewBag.Page = searchProducts.PageNumber;
            searchProducts.IsPagedSearch = true;
            Result result = await searchProductsService.HandleAsync(searchProducts);
            ViewBag.PageCount = (double)(Math.Ceiling(((double)result.TotalRecordCount / (double)searchProducts.PageSize)));
            return View(result.Value);
        }
        public IActionResult ProductsDetails()
        {
            return View();
        }
        public async Task<IActionResult> Cart()
        {
            // ilk ürün eklendiğinde kullanıcının kartı yoksa yeni cart oluşturacak

            var cart = new GetCart();
            cart.UserName = User.Identity.Name;
            var result = await getCartService.HandleAsync(cart);
            return View(result.Value);
        }
        public async Task<IActionResult> Checkout()
        {
            var deliveryAddress = new AddressQuery();
            var searchCities = new SearchCitys();
            var searchCountries = new SearchCountrys();

            Result resultCountry = await searchCountriesService.HandleAsync(searchCountries);
            Result resultCity = await searchCitiesService.HandleAsync(searchCities);

            ViewBag.Cities = new SelectList(resultCity.Value, "Id", "Name", deliveryAddress.CountryId);
            ViewBag.Countries = new SelectList(resultCountry.Value, "Id", "Name", deliveryAddress.CityId);

            return View();
        }
    }
}