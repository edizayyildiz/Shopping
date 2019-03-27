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
    public class SearchCountriesHandler : CommandHandler<Commands.SearchCountrys>
    {
        private readonly IRepository<Country> countryRepository;
        public SearchCountriesHandler(IRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchCountrys command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<Country, object>> orderby;
            switch (command.SortField)
            {
                case "name":
                    orderby = o => o.Name;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Country, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);


            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = countryRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<CountryQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} ülkenin {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = countryRepository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<CountryQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet ülke bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
