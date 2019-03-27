using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Cms
{
    public class DeletePostPostCategoryHandler : CommandHandler<Commands.DeletePostPostCategory>
    {
        private readonly IRepository<PostPostCategory> postpostcategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeletePostPostCategoryHandler(IUnitOfWork unitOfWork, IRepository<PostPostCategory> postpostcategoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.postpostcategoryRepository = postpostcategoryRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeletePostPostCategory command)
        {
            // get the model from database
            var model = postpostcategoryRepository.Get(command.Id);
            Result result;
            // if nothing found
            if (model == null)
            {
                result = new Result(false, command.Id, "Posta ile posta kategorisi arasındaki ilişki bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // delete the model
            postpostcategoryRepository.Delete(model);
            await unitOfWork.SaveChangesAsync();



            result = new Result(true, command.Id, "1 adet posta ile posta kategorisi arasındaki ilişki silindi.", true, 1);
            // return the result
            return await Task.FromResult(result);
        }
    }
}
