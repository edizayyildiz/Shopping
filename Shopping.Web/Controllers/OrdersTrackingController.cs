using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service;
using Shopping.Service.Commands;

namespace Shopping.Web.Controllers
{
    public class OrdersTrackingController : BaseController
    {
        private readonly ICommandHandler<GetOrder> orderTrackingService;
        private readonly ICommandHandler<SearchOrderItems> orderItemService;
        private readonly ICommandHandler<SearchOrders> searchOrdersService;

        //private readonly ApplicationIdentity identity;
        private readonly IHttpContextAccessor contextAccessor;
        public OrdersTrackingController(ICommandHandler<GetOrder> orderTrackingService, ICommandHandler<SearchProductCategories> SearchProductCategoriesService, ICommandHandler<SearchOrderItems> orderItemService, IHttpContextAccessor contextAccessor, ICommandHandler<SearchOrders> searchOrdersService) : base(SearchProductCategoriesService)
        {
            this.orderTrackingService = orderTrackingService;
            this.searchOrdersService = searchOrdersService;
            this.orderItemService = orderItemService;
            this.contextAccessor = contextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            //identity eklenmesi gerekiyor
            var user = contextAccessor.HttpContext.User.Identity.Name;
            var searchOrder = new SearchOrders();
            searchOrder.IsPagedSearch = true;
            Result result = await searchOrdersService.HandleAsync(searchOrder);
            if(user==result.Value.UserName)
            {
            return View(result.Value);
            }
            return View();
        }

    }
}