using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditCouponHandler : CommandHandler<Commands.EditCoupon>
    {
        private readonly IRepository<Coupon> couponRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditCouponHandler(IUnitOfWork unitOfWork, IRepository<Coupon> couponRepository)
        {
            this.unitOfWork = unitOfWork;
            this.couponRepository = couponRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditCoupon command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(false, command.Id, "id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.CouponNo))
            {
                result = new Result(false, command.CouponNo, "CouponNo gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result = new Result(false, command.Name, "Ad gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, command.Name, "en fazla 200 karekter gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            // map command to the model
            var model = Mapper.Map<Coupon>(command);

            // mark the model to update
            couponRepository.Update(model);

            // save changes to database
            unitOfWork.SaveChanges();

            // return the result
            return new Result( true, model.Id, "Kupon başarıyla güncellendi.", false, 1);
        }
    }
}
