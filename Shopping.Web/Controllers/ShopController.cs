using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Model.Entities;
using Shopping.Service;
using Shopping.Service.Commands;
using Shopping.Service.Handlers.Store;
using Shopping.Service.Queries;
using Shopping.Service.Queries.Commerce;

namespace Shopping.Web.Controllers
{
    public class ShopController : BaseController
    {
        private ICommandHandler<AddProduct> addProductService;
        private ICommandHandler<SearchProducts> searchProductsService;
        private ICommandHandler<SearchCitys> searchCitiesService;
        private ICommandHandler<SearchCountrys> searchCountriesService;
        private ICommandHandler<SearchStores> searchStoresService;
        private ICommandHandler<SearchCarts> searchCartService;
        private ICommandHandler<GetCart> getCartService;

        
        public ShopController(ICommandHandler<SearchCountrys> searchCountriesService, ICommandHandler<SearchCitys> searchCitiesService, ICommandHandler<SearchProducts> searchProductsService, ICommandHandler<SearchProductCategories> SearchProductCategoriesService, ICommandHandler<SearchCarts> searchCartService, ICommandHandler<GetCart> getCartService) : base(SearchProductCategoriesService)
        {
            //this.addProductService = addProductService;
            this.searchProductsService = searchProductsService;
            this.searchCitiesService = searchCitiesService;
            this.searchCountriesService = searchCountriesService;
            //this.searchStoresService = searchStoresService;
            this.searchCartService = searchCartService;
            this.getCartService = getCartService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Stores(SearchStores searchStores)
        {
            //var stores = await searchStoresService.HandleAsync(searchStores);
            //if(((IEnumerable<Store>)stores.Value).FirstOrDefault(s => s.Name == searchStores.Name) == null)
            //{
            //    ViewBag.Stores = await searchStoresService.HandleAsync(searchStores);
            //}

            //var getStores = new GetStore();
            //var sonuc = getStoreService.HandleAsync(getStores).Result;
            //ViewBag.Stores = sonuc.Value;

            Result result = await searchStoresService.HandleAsync(searchStores);
            return View(result.Value);
        }

        public async Task<IActionResult> Products(SearchProducts searchProducts)
        {       
            Result result = await searchProductsService.HandleAsync(searchProducts);
            return View(result.Value);
        }
        public async Task<IActionResult> ProductsList(SearchProducts searchProducts)
        {
            
            ViewBag.PageSize = searchProducts.PageSize;
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
            // ilk ürün eklendiğinde kullanıcının sepeti yoksa yeni cart oluşturacak

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