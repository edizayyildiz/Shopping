using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Adresleri arar.")]
    public class SearchAddresses : Command, ISearchCommand
    {
        public SearchAddresses()
        {
            IsAdvancedSearch = false;
            SortField = "createdAt";
            SortOrder = "desc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string CityId { get; set; }
        public string CountryId { get; set; }
        public string DistrictId { get; set; }
        public string AddressDescription { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string IdentityNumber { get; set; }
        public bool? ShowInHome { get; set; }
        public bool? IsActive { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
