using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class CountryQuery : Query
    {

        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
