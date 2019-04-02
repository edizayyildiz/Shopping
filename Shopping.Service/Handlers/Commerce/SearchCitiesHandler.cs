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
    public class SearchCitiesHandler : CommandHandler<Commands.SearchCitys>
    {
        private readonly IRepository<City> cityRepository;
        public SearchCitiesHandler(IRepository<City> cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchCitys command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<City, object>> orderby;
            switch (command.SortField)
            {
                case "name":
                    orderby = o => o.Name;
                    break;
                case "countryId":
                    orderby = o => o.CountryId;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<City, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true)
                && (command.CountryId != null ? w.CountryId == command.CountryId : true);

            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = cityRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc, "Country", "Districts")
                .Select(x => Mapper.Map<CityQuery>(x)).ToList();
                // return the paged query
                result= new Result(true, value, $"Bulunan {totalRecordCount} şehirin {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = cityRepository.GetMany(where, orderby, desc, "Country", "Districts")
                .Select(x => Mapper.Map<CityQuery>(x)).ToList();
                // return the query
                result= new Result(true, value, $"{value.Count()} adet şehir bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
