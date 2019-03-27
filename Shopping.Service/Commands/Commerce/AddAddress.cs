using Shopping.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Create, "Yeni Adres oluşturur.")]
    public class AddAddress : Command
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string CityId { get; set; }
        public string CountryId { get; set; }
        public string DistrictId { get; set; }
        public string AddressDescription { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string IdentityNumber { get; set; }

    }
}
