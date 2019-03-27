using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class Country:BaseEntity
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Addresses = new HashSet<Address>();
        }
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
