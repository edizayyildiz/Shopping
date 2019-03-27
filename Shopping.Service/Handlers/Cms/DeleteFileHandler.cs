using Shopping.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteFileHandler : CommandHandler<Commands.DeleteFile>
    {
        private readonly IRepository<Shopping.Model.Entities.File> fileRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteFileHandler(IUnitOfWork unitOfWork, IRepository<Shopping.Model.Entities.File> fileRepository)
        {
            this.unitOfWork = unitOfWork;
            this.fileRepository = fileRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteFile command)
        {
            Result result;
            // get the model from database
            var model = await fileRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result= new Result( true,model.Id, "Dosya bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // delete the model
            fileRepository.Delete(model);
           await unitOfWork.SaveChangesAsync();


            // return the query result
            result= new Result( true, command.Id, "1 adet dosya silindi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
