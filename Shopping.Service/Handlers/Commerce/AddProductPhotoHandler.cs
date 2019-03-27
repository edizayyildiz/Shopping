using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddProductPhotoHandler : CommandHandler<Commands.AddProductPhoto>
    {
        private readonly IRepository<ProductPhoto> productphotoRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddProductPhotoHandler(IUnitOfWork unitOfWork, IRepository<ProductPhoto> productphotoRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productphotoRepository = productphotoRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddProductPhoto command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Medium))
            {
                result= new Result(false, command.Medium, "Orta Boy Resim Adı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Medium.Length > 200)
            {
                result=new Result(false, command.Medium, "Orta Boy Resim Adı 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Small))
            {
                result= new Result(false, command.Small, "Küçük Boy Resim Adı gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Small.Length > 200)
            {
                result=new Result(false, command.Small, "Küçük Boy Resim Adı 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Large))
            {
                result= new Result(false, command.Large, "Büyük Boy Resim Adı gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Large.Length > 200)
            {
                result= new Result(false, command.Large, "Büyük Boy Resim Adı 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Alt))
            {
                result= new Result(false, command.Alt, "Açıklama gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Alt.Length > 4000)
            {
                result= new Result(false, command.Alt, "Açıklama 4000 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.ProductId))
            {
                result= new Result(false, command.ProductId, "ÜrünId gereklidir.", true,null);
                return await Task.FromResult(result);
            }


            // map command to the model
            var model = Mapper.Map<ProductPhoto>(command);

            // mark the model to insert
            productphotoRepository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true,model.Id, "Ürün resmi başarıyla eklendi.", true, 1);

            return await Task.FromResult(result);
        }
    }
}
