using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class SearchOrdersHandler : CommandHandler<Commands.SearchOrders>
    {
        private readonly IRepository<Order> orderRepository;
        private readonly ApplicationIdentity identity;
        public SearchOrdersHandler(IRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
            this.identity=identity;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchOrders command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<Order, object>> orderby;
            switch (command.SortField)
            {
                case "userName":
                    orderby = o => o.UserName;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            string userName = command.UserName;
            Expression<Func<Order, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => w.UserName.Contains(userName);


            }
            else
            {
                where = w => w.UserName.Contains(userName);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = orderRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc, "OrderItems", "OrderItems.Product", "OrderItems.Product.Images", "OrderItems.Product.Store", "OrderItems.Shipper", "DeliveryAddress", "DeliveryAddress.City", "DeliveryAddress.Country", "DeliveryAddress.District")
                .Select(x => Mapper.Map<OrderQuery>(x)).ToList();
                // return the paged query
                result= new Result(true, value, $"Bulunan {totalRecordCount} sipariş listesi {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = orderRepository.GetMany(where, orderby, desc, "OrderItems", "OrderItems.Product", "OrderItems.Product.Images", "OrderItems.Product.Store", "OrderItems.Shipper", "DeliveryAddress", "DeliveryAddress.City", "DeliveryAddress.Country", "DeliveryAddress.District")
                .Select(x => Mapper.Map<OrderQuery>(x)).ToList();
                // return the query
                result= new Result(true, value, $"{value.Count()} adet sipariş bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
