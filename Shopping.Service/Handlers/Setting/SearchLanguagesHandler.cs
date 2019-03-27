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

namespace Shopping.Service.Handlers.Setting
{
    public class SearchLanguageHandler : CommandHandler<Commands.SearchLanguage>
    {
        private readonly IRepository<Language> languageRepository;
        public SearchLanguageHandler(IRepository<Language> languageRepository)
        {
            this.languageRepository = languageRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchLanguage command)
        {
            Result result;
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;

            // define the sort expression
            Expression<Func<Language, object>> orderby;
            switch (command.SortField)
            {
                case "name":
                    orderby = o => o.Name;
                    break;
                case "isActive":
                    orderby = o => o.IsActive;
                    break;
                case "flag":
                    orderby = o => o.Flag;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Language, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true)
                && (command.Flag != null ? w.Flag == command.Flag : true);
            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = languageRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<LanguageQuery>(x)).ToList();
                // return the paged query
                result= new Result( true, value, $"Bulunan {totalRecordCount} dillerin {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = languageRepository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<LanguageQuery>(x)).ToList();
                // return the query
                result= new Result( true, value, $"{value.Count()} adet dil bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
