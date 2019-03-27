using Shopping.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Create, "Yeni Ürün Rengi oluşturur.")]
    public class AddProductColor : Command
    {
        public string ProductId { get; set; }
        public string ColorId { get; set; }

    }
}
