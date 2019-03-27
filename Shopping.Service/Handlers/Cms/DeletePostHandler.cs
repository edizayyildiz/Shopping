using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeletePostHandler : CommandHandler<Commands.DeletePost>
    {
        private readonly IRepository<Post> postRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeletePostHandler(IUnitOfWork unitOfWork, IRepository<Post> postRepository)
        {
            this.unitOfWork = unitOfWork;
            this.postRepository = postRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeletePost command)

        {
            Result result;
            // get the model from database
            var model =await postRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result= new Result( true,model.Id, "Posta bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // delete the model
            postRepository.Delete(model);
            await unitOfWork.SaveChangesAsync();


            // return the query result
            result= new Result( true, command.Id, "1 adet posta silindi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
