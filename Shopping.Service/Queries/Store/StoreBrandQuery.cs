using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class StoreBrandQuery:Query
    {
        public string StoreId { get; set; }
        public string BrandId { get; set; }

    }
}
