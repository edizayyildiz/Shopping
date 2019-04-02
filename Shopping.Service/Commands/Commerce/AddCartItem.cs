using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Create, "Sepete ürün ekler.")]
    public class AddCartItem : Command
    {
        public string ProductId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
    }
}
