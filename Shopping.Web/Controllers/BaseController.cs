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

        public BaseController(ICommandHandler<SearchProductCategories> searchProductCategoriesService)
        {
            this.SearchProductCategoriesService = searchProductCategoriesService;

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
            ViewBag.Categories = sonuc.Value;
            base.OnActionExecuted(context);
        }
    }
}