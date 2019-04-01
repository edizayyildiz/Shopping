using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
   public class RecentlyDisplayedProduct:BaseEntity
    {
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string UserName { get; set; }
        public DateTime DisplayDate { get; set; }
    }
}
