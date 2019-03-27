using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteColorHandler : CommandHandler<Commands.DeleteColor>
    {
        private readonly IRepository<Color> colorRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteColorHandler(IUnitOfWork unitOfWork, IRepository<Color> colorRepository)
        {
            this.unitOfWork = unitOfWork;
            this.colorRepository = colorRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteColor command)
        {
            Result result;
            // get the model from database
            var model = colorRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(true, command.Id, "Renk bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // delete the model
            colorRepository.Delete(model);
            unitOfWork.SaveChanges();


            // return the query result
            result = new Result(true, command.Id, "1 adet renk silindi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
