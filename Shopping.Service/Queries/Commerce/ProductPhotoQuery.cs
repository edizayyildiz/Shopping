using Shopping.Model.Entities;
using Shopping.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class ProductPhotoQuery : Query
    {
       
        public string Medium { get; set; }
        public string Small { get; set; }
        public string Large { get; set; }
        public string Alt { get; set; }
        public string ProductId { get; set; }
    }
}
