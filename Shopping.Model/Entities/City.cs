using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class City:BaseEntity
    {
        public City()
        {
            Districts = new HashSet<District>();
            Addresses = new HashSet<Address>();
        }
        
        public string Name { get; set; }
        public string CountryId { get; set; }
        public Country Country { get; set; }
        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

    }
}
