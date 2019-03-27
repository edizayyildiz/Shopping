using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeletePostCategoryHandler : CommandHandler<Commands.DeletePostCategory>
    {
        private readonly IRepository<PostCategory> postcategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeletePostCategoryHandler(IUnitOfWork unitOfWork, IRepository<PostCategory> postcategoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.postcategoryRepository = postcategoryRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeletePostCategory command)
        {
            Result result;
            // get the model from database
            var model =await postcategoryRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result= new Result( true,model.Id, "Posta kategorisi bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // delete the model
            postcategoryRepository.Delete(model);
           await unitOfWork.SaveChangesAsync();


            // return the query result
            result= new Result( true, command.Id, "1 adet posta kategorisi silindi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
