using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class DeleteCouponHandler : CommandHandler<Commands.DeleteCoupon>
    {
        private readonly IRepository<Coupon> couponRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteCouponHandler(IUnitOfWork unitOfWork, IRepository<Coupon> couponRepository)
        {
            this.unitOfWork = unitOfWork;
            this.couponRepository = couponRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteCoupon command)
        {
            // get the model from database
            var model = couponRepository.Get(command.Id);
            Result result;
            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, model.Name, "Kupon bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // delete the model
            couponRepository.Delete(model);

            await unitOfWork.SaveChangesAsync();


            // return the query result
            result = new Result(true,command.Id, "1 adet kupon silindi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
