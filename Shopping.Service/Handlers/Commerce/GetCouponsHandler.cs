using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class GetCouponsHandler : CommandHandler<Commands.GetCoupons>
    {
        private readonly IRepository<Coupon> couponRepository;
        public GetCouponsHandler(IRepository<Coupon> couponRepository)
        {
            this.couponRepository = couponRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetCoupons command)
        {
            // get the model from database
            var model = couponRepository.Get(command.Id);
            Result result;
            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(true, null, "Kupon bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<CouponQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet kupon bulundu.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
