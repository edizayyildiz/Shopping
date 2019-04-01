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
        public ShopController(ICommandHandler<SearchProductCategories> SearchProductCategoriesService) : base(SearchProductCategoriesService)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductsGrid()
        {
            return View();
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