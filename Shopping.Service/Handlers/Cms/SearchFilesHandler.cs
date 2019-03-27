using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using Shopping.Service.Queries.Cms;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
  public class SearchFilesHandler : CommandHandler<Commands.SearchFiles>
    {
        private readonly IRepository<File> fileRepository; 
        public SearchFilesHandler(IRepository<File> fileRepository) {
            this.fileRepository = fileRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchFiles command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
    
            // define the sort expression
            Expression<Func<File, object>> orderby;
            switch (command.SortField) {
                case "name":
                    orderby = o => o.Name;
                    break;
                case "isActive":
                    orderby = o => o.IsActive;
                    break;
                case "category":
                    orderby = o => o.Category;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);
            
            // define the filter
            Expression<Func<File, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name)?w.Name.Contains(command.Name):true) 
                && (command.IsActive!= null?w.IsActive == command.IsActive:true)
                && (command.Category!= null?w.Category == command.Category:true);
                
                
            } else
            {
                where = w => (!string.IsNullOrEmpty(command.Name)?w.Name.Contains(command.Name):true);
            }
                
            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = fileRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x=>Mapper.Map<FileQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} dosyanın {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else 
            {
                var value = fileRepository.GetMany(where, orderby, desc)
                .Select(x=>Mapper.Map<FileQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet dosya bulundu.", true, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
