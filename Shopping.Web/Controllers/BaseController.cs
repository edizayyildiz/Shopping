using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shopping.Service;
using Shopping.Service.Commands;

namespace Shopping.Web.Controllers
{
    public class BaseController : Controller
    {
        public ICommandHandler<SearchProductCategories> SearchProductCategoriesService;
        protected ICommandHandler<GetCart> getCartService;

        public BaseController(ICommandHandler<SearchProductCategories> searchProductCategoriesService, ICommandHandler<GetCart> getCartService)
        {
            this.SearchProductCategoriesService = searchProductCategoriesService;
            this.getCartService = getCartService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
        // Bu method tüm action lardan sonra çalışır.
        public override void  OnActionExecuted(ActionExecutedContext context)
        {
            var searchProductCategoryCommand = new SearchProductCategories();
            var sonuc = SearchProductCategoriesService.HandleAsync(searchProductCategoryCommand).Result;

            //var cart = new GetCart();
            //cart.UserName = User.Identity.Name;
            //var result = getCartService.HandleAsync(cart).Result;

            ViewBag.Categories = sonuc.Value;
            
            base.OnActionExecuted(context);
        }
    }
}