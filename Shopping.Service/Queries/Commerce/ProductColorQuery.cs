using Shopping.Model.Entities;
using Shopping.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class ProductColorQuery :Query
    {
       
        public string Name { get; set; }
        public string Alt { get; set; }
        public string ProductId { get; set; }
        public string ColorId { get; set; }

    }
}
