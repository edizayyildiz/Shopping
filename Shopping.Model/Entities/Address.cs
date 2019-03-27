using Shopping.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class Address:BaseEntity
    {
        public Address()
        {
            OrdersToDeliver = new HashSet<Order>();
            OrdersToInvoice = new HashSet<Order>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
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
        public virtual ICollection<Order> OrdersToDeliver { get; set; }
        public virtual ICollection<Order> OrdersToInvoice { get; set; }
    }
}
