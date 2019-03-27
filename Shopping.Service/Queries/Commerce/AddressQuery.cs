using Shopping.Model.Entities;
using Shopping.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class AddressQuery:Query
    {
  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string CityId { get; set; }
        public City City { get; set; }
        public string CountryId { get; set; }
        public Country Country { get; set; }
        public string DistrictId { get; set; }
        public District District { get; set; }
        public string AddressDescription { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string IdentityNumber { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }



    }
}
