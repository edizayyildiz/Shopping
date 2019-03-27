using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditProductPhotoHandler : CommandHandler<Commands.EditProductPhoto>
    {
        private readonly IRepository<ProductPhoto> productphotoRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditProductPhotoHandler(IUnitOfWork unitOfWork, IRepository<ProductPhoto> productphotoRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productphotoRepository = productphotoRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditProductPhoto command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(false, command.Id, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Medium))
            {
                result = new Result(false, command.Id, "Orta Boy Resim Adı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Medium.Length > 200)
            {
                result = new Result(false, command.Id, "Orta Boy Resim Adı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
              
            }
            if (string.IsNullOrWhiteSpace(command.Small))
            {
                result = new Result(false, command.Id, "Küçük Boy Resim Adı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Small.Length > 200)
            {
                result = new Result(false, command.Id, "Küçük Boy Resim Adı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Large))
            {
                result = new Result(false, command.Id, "Büyük Boy Resim Adı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Large.Length > 200)
            {
                result = new Result(false, command.Id, "Büyük Boy Resim Adı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Alt))
            {
                result = new Result(false, command.Id, "Açıklama gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Alt.Length > 200)
            {
                result = new Result(false, command.Id, "Açıklama 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.ProductId))
            {
                result = new Result(false, command.Id, "ÜrünId gereklidir.", true, null);
                return await Task.FromResult(result);
            }


            // map command to the model
            var model = Mapper.Map<ProductPhoto>(command);

            // mark the model to update
            productphotoRepository.Update(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true, model.Id, "Ürün resmi başarıyla güncellendi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
