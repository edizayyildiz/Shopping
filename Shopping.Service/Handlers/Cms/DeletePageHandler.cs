using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeletePageHandler : CommandHandler<Commands.DeletePage>
    {
        private readonly IRepository<Page> pageRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeletePageHandler(IUnitOfWork unitOfWork, IRepository<Page> pageRepository)
        {
            this.unitOfWork = unitOfWork;
            this.pageRepository = pageRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeletePage command)
        {
            Result result;
            // get the model from database
            var model = await pageRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result=new Result( true,model.Id, "Sayfa bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // delete the model
            pageRepository.Delete(model);
           await unitOfWork.SaveChangesAsync();


            // return the query result
            result= new Result( true, command.Id, "1 adet sayfa silindi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
