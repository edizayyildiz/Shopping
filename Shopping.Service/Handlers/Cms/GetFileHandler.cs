using Shopping.Data;
using Shopping.Service.Queries.Cms;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class GetFileHandler : CommandHandler<Commands.GetFile>
    {
        private readonly IRepository<Shopping.Model.Entities.File> fileRepository;
        public GetFileHandler(IRepository<Shopping.Model.Entities.File> fileRepository)
        {
            this.fileRepository = fileRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetFile command)
        {
            // get the model from database
            var model = fileRepository.Get(command.Id);
            Result result;
            // if nothing found
            if (model == null)
            {
                // return the not found result
                return new Result(true, null, "Dosya bulunamadı.", true, 0);
            }
            // map the model to query
            var value = Mapper.Map<FileQuery>(model);

            // return the query result
            result= new Result(true, value, "1 adet dosya bulundu.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
