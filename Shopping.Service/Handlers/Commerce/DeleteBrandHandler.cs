using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteBrandHandler : CommandHandler<Commands.DeleteBrand>
    {
        private readonly IRepository<Brand> brandRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteBrandHandler(IUnitOfWork unitOfWork, IRepository<Brand> brandRepository)
        {
            this.unitOfWork = unitOfWork;
            this.brandRepository = brandRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteBrand command)
        {
            Result result;
            // get the model from database
            var model = brandRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                return new Result(true, null,  "Marka bulunamadı.", true, 0);
               
            }
            // delete the model
            brandRepository.Delete(model);
            unitOfWork.SaveChanges();


            // return the query result
            
            result = new Result(true, command.Id, "Ürün resmi başarıyla eklendi.", false, 1);

            return await Task.FromResult(result);
        }
    }
}
