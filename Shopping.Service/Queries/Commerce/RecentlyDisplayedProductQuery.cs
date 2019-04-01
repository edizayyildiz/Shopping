using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class RecentlyDisplayedProductQuery : Query
    {
        public string ProductId { get; set; }
        public string UserName { get; set; }
        public DateTime DisplayDate { get; set; }
    }
}
