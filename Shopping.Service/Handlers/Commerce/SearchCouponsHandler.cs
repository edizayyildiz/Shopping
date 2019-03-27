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
    public class SearchCouponsHandler : CommandHandler<Commands.SearchCoupons>
    {
        private readonly IRepository<Coupon> couponRepository;
        public SearchCouponsHandler(IRepository<Coupon> couponRepository)
        {
            this.couponRepository = couponRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchCoupons command)
        {
            Result result;
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;

            // define the sort expression
            Expression<Func<Coupon, object>> orderby;
            switch (command.SortField)
            {
                case "couponNo":
                    orderby = o => o.CouponNo;
                    break;
                case "name":
                    orderby = o => o.Name;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Coupon, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.CouponNo) ? w.CouponNo.Contains(command.CouponNo) : true)
                && (command.Name != null ? w.Name == command.Name : true);

            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.CouponNo) ? w.CouponNo.Contains(command.CouponNo) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = couponRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc, "Order", "Store")
                .Select(x => Mapper.Map<CouponQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} kuponun {command.PageNumber}. sayfasındaki kayıtlar.", false, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = couponRepository.GetMany(where, orderby, desc, "Order", "Store")
                .Select(x => Mapper.Map<CouponQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet kupon bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
