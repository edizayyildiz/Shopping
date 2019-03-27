using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class SearchBrandsHandler : CommandHandler<Commands.SearchBrands>
    {
        private readonly IRepository<Brand> brandRepository;
        public SearchBrandsHandler(IRepository<Brand> brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchBrands command)
        {
            Result result;
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;

            // define the sort expression
            Expression<Func<Brand, object>> orderby;
            switch (command.SortField)
            {
                case "name":
                    orderby = o => o.Name;
                    break;
                case "isActive":
                    orderby = o => o.IsActive;
                    break;
                case "showInHome":
                    orderby = o => o.ShowInHome;
                    break;
                case "image":
                    orderby = o => o.Image;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Brand, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true)
                && (command.ShowInHome != null ? w.ShowInHome == command.ShowInHome : true);
            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = brandRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<BrandQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} markanın {command.PageNumber}. sayfasındaki kayıtlar.", false, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = brandRepository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<BrandQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet marka bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
