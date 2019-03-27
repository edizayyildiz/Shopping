using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{

    [Describe(CommandType.Commerce, Authorities.Create, "Yeni Ürün Resmi oluşturur.")]
    public class AddProductPhoto : Command
    {
        public string Medium { get; set; }
        public string Small { get; set; }
        public string Large { get; set; }
        public string Alt { get; set; }
        public string ProductId { get; set; }

    }
}
