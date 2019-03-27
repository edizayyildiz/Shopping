using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    // ilçe
    public class District:BaseEntity
    {
        public District()
        {
            Addresses = new HashSet<Address>();
        }
        public string Name { get; set; }
        public string CityId { get; set; }
        public City City { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
