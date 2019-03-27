using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using Shopping.Service.Queries.Commerce;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class SearchDistrictsHandler : CommandHandler<Commands.SearchDistricts>
    {
        private readonly IRepository<District> districtRepository;
        public SearchDistrictsHandler(IRepository<District> districtRepository)
        {
            this.districtRepository = districtRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchDistricts command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<District, object>> orderby;
            switch (command.SortField)
            {
                case "name":
                    orderby = o => o.Name;
                    break;
                case "cityId":
                    orderby = o => o.CityId;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<District, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true)
                && (command.CityId != null ? w.CityId == command.CityId : true);

            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = districtRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc, "City")
                .Select(x => Mapper.Map<DistrictQuery>(x)).ToList();
                // return the paged query
                result= new Result(true, value, $"Bulunan {totalRecordCount} ilçenin {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = districtRepository.GetMany(where, orderby, desc, "City")
                .Select(x => Mapper.Map<DistrictQuery>(x)).ToList();
                // return the query
                result= new Result(true, value, $"{value.Count()} adet ilçe bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
