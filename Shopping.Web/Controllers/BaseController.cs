using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shopping.Model.Entities;
using Shopping.Service;
using Shopping.Service.Commands;
using Shopping.Service.Queries.Commerce;

namespace Shopping.Web.Controllers
{
    public class BaseController : Controller
    {
        public ICommandHandler<SearchProductCategories> SearchProductCategoriesService;
        protected ICommandHandler<GetCart> getCartService;
        protected ICommandHandler<GetCartItem> getCartItemService;

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

            var cart = new GetCart();
            cart.UserName = User.Identity.Name;

            var cartItems = new List<CartItem>();

            var result = getCartService.HandleAsync(cart).Result;
            ViewBag.GetCartItems = (IList<CartItem>)result.Value.CartItems ?? cartItems;
            ViewBag.CartTotal = (decimal?)result.Value.CartTotal;

            ViewBag.Categories = sonuc.Value;
            
            base.OnActionExecuted(context);
        }
    }
}