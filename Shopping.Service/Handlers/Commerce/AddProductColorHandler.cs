using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddProductColorHandler : CommandHandler<Commands.AddProductColor>
    {
        private readonly IRepository<ProductColor> productcolorRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddProductColorHandler(IUnitOfWork unitOfWork, IRepository<ProductColor> productcolorRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productcolorRepository = productcolorRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddProductColor command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.ProductId))
            {
               
                result = new Result(false, command.ProductId, "Ürün Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.ColorId))
            {                

                result = new Result(false, command.ColorId, "Ürün Rengi Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }

            // map command to the model
            var model = Mapper.Map<ProductColor>(command);

            // mark the model to insert
            productcolorRepository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();           

            result = new Result(true, model.Id, "Ürün rengi başarıyla eklendi.", true, 1);
            // return the result
            return await Task.FromResult(result);
        }
    }
}
