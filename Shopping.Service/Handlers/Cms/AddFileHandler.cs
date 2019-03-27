using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddFileHandler : CommandHandler<Commands.AddFile>
    {
        private readonly IRepository<Model.Entities.File> fileRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddFileHandler(IUnitOfWork unitOfWork, IRepository<Model.Entities.File> fileRepository)
        {
            this.unitOfWork = unitOfWork;
            this.fileRepository = fileRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddFile command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result = new Result(false, command.Name, "Ad gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, command.Name, "Ad 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.OriginalName))
            {
                result = new Result(false, command.OriginalName, "Dosya Adı gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.OriginalName.Length > 200)
            {
                result = new Result(false, command.OriginalName, "Dosya Adı 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Alt))
            {
                result = new Result(false, command.Alt, "Açıklama gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Alt.Length > 4000)
            {
                result= new Result(false, command.Alt, "Açıklama 4000 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Category))
            {
                result= new Result(false, command.Category, "Kategori gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Category.Length > 200)
            {
                result= new Result(false, command.Category, "Kategori 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Type))
            {
                result= new Result(false, command.Type, "Tür gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Type.Length > 200)
            {
                result = new Result(false, command.Type, "Tür 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Extension))
            {
                result= new Result(false, command.Extension, "Uzantı gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Extension.Length > 200)
            {
                result= new Result(false, command.Extension, "Uzantı 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }


            // map command to the model
            var model = Mapper.Map<Model.Entities.File>(command);

            // mark the model to insert
            fileRepository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result= new Result(true,model.Id,"Dosya başarıyla eklendi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
