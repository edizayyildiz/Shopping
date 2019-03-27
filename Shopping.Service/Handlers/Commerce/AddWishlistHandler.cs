using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddWishlistHandler : CommandHandler<Commands.AddWishlist>
    {
        private readonly IRepository<Wishlist> wishlistRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AddWishlistHandler(IUnitOfWork unitOfWork, IRepository<Wishlist> wishlistRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.unitOfWork = unitOfWork;
            this.wishlistRepository = wishlistRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddWishlist command)
        {
            // validate the command
            Result result;
            if (string.IsNullOrWhiteSpace(command.ProductId))
            {
                result = new Result(false, command.ProductId, " id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            // map command to the model
            var model = Mapper.Map<Wishlist>(command);

            model.UserName = "emir"; //httpContextAccessor.HttpContext.Session.Id; // Session Id

            // mark the model to insert
            wishlistRepository.Insert(model);

            // save changes to database
            try
            {
                unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                return new Result( true, model.Id, ex.Message, true, 0);
            }

            // return the result
            return new Result( true, model.Id, "Dilek başarıyla eklendi.", false, 1);
        }
    }
}
