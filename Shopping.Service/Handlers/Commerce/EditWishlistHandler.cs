using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class EditWishlistHandler : CommandHandler<Commands.EditWishlist>
    {
        private readonly IRepository<Wishlist> wishlistRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditWishlistHandler(IUnitOfWork unitOfWork, IRepository<Wishlist> wishlistRepository)
        {
            this.unitOfWork = unitOfWork;
            this.wishlistRepository = wishlistRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditWishlist command)
        {
            // validate the command
            Result result;
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(false, command.Id, "Id gereklidir.", true,null);
                return await Task.FromResult(result);
                
            }
            if (string.IsNullOrWhiteSpace(command.UserName))
            {
                result = new Result(false, command.UserName, "Kullanıcı Adı gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.UserName.Length > 200)
            {
                result = new Result(false, command.UserName, "Kullanıcı Adı 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.ProductId))
            {
                result = new Result(false, command.ProductId, "Ürün ID gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            // map command to the model
            var model = Mapper.Map<Wishlist>(command);

            // mark the model to update
            wishlistRepository.Update(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true,model.Id, "Dilek başarıyla güncellendi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
