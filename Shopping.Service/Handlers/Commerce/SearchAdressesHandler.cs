using Shopping.Data;
using Shopping.Model.Entities;
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
    public class SearchAddressesHandler : CommandHandler<Commands.SearchAddresses>
    {
        private readonly IRepository<Address> addressRepository;
        public SearchAddressesHandler(IRepository<Address> addressRepository)
        {
            this.addressRepository = addressRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchAddresses command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<Address, object>> orderby;
            switch (command.SortField)
            {
                case "email":
                    orderby = o => o.Email;
                    break;
                case "firstName":
                    orderby = o => o.FirstName;
                    break;
                case "lastName":
                    orderby = o => o.LastName;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Address, bool>> where;

            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.FirstName) ? w.FirstName.Contains(command.FirstName) : true)
                && (command.LastName != null ? w.LastName == command.LastName : true)
                && (command.Email != null ? w.DistrictId == command.Email : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true);

            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.FirstName) ? w.FirstName.Contains(command.FirstName) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = addressRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc, "City", "Country", "District")
                .Select(x => Mapper.Map<AddressQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} adresin {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = addressRepository.GetMany(where, orderby, desc, "City", "Country", "District")
                .Select(x => Mapper.Map<AddressQuery>(x)).ToList();
                // return the query
                result= new Result(true, value, $"{value.Count()} adet adres bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
