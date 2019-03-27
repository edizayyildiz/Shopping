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
    public class SearchOrderItemsHandler : CommandHandler<Commands.SearchOrderItems>
    {
        private readonly IRepository<OrderItem> orderItemRepository;
        public SearchOrderItemsHandler(IRepository<OrderItem> orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchOrderItems command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<OrderItem, object>> orderby;
            switch (command.SortField)
            {
                case "orderId":
                    orderby = o => o.OrderId;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter

            Expression<Func<OrderItem, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (w.OrderId == command.OrderId);
            }
            else
            {
                where = w => (w.OrderId == command.OrderId);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = orderItemRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc, "Product", "Shipper")
                .Select(x => Mapper.Map<OrderItemQuery>(x)).ToList();
                // return the paged query
                result= new Result(true, value, $"Bulunan {totalRecordCount} sipariş öğesi {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = orderItemRepository.GetMany(where, orderby, desc, "Product", "Shipper")
                .Select(x => Mapper.Map<OrderItemQuery>(x)).ToList();
                // return the query
                result= new Result(true, value, $"{value.Count()} adet sipariş öğesi bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
