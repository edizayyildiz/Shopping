using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class AddCouponHandler : CommandHandler<Commands.AddCoupon>
    {
        private readonly IRepository<Coupon> couponRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddCouponHandler(IUnitOfWork unitOfWork, IRepository<Coupon> couponRepository)
        {
            this.unitOfWork = unitOfWork;
            this.couponRepository = couponRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddCoupon command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.CouponNo))
            {
                result = new Result(false, command.CouponNo, "Kupon No gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result = new Result(false, command.Name, "Kupon Adı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, command.Name, "Kupon Adı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            // map command to the model
            var model = Mapper.Map<Coupon>(command);

            // mark the model to insert
            couponRepository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true, model.Id, "Kupon başarıyla eklendi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
