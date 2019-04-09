using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class AddCartHandler : CommandHandler<Commands.AddCart>
    {
        private readonly IRepository<Cart> chartRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddCartHandler(IRepository<Cart> chartRepository, IUnitOfWork unitOfWork)
        {
            this.chartRepository = chartRepository;
            this.unitOfWork = unitOfWork;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddCart command)
        {
            Result result;

            var model = Mapper.Map<Cart>(command);

            chartRepository.Insert(model);
            await unitOfWork.SaveChangesAsync();

            result = new Result(true, model.Id, "Sepet oluşturuldu.", true, 1);
            return Task.FromResult(result);
        }
    }
}
