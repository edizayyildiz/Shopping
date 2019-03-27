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
    public class SearchColorsHandler : CommandHandler<Commands.SearchColors>
    {
        private readonly IRepository<Color> colorRepository;
        public SearchColorsHandler(IRepository<Color> colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchColors command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<Color, object>> orderby;
            switch (command.SortField)
            {
                case "name":
                    orderby = o => o.Name;
                    break;
                case "isActive":
                    orderby = o => o.IsActive;
                    break;
                case "value":
                    orderby = o => o.Value;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Color, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true)
                && (command.Value != null ? w.Value == command.Value : true);
            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {                

                var value2 = colorRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc);
                var value = value2.Select(x => Mapper.Map<ProductQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} rengin {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);


            }
            else
            {               
                
                var value2 = colorRepository.GetMany(where, orderby, desc);
                var value = value2.Select(x => Mapper.Map<ProductQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()}adet renk bulundu.", true, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
