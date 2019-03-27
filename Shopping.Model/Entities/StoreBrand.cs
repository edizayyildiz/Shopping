using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class StoreBrand:BaseEntity
    {
        public string StoreId { get; set; }
        public Store Store { get; set; }

        public string BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
