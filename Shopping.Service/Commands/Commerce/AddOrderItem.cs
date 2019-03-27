using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Create, "Yeni sipariş öğesi oluşturur.")]
    public class AddOrderItem : Command
    {
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ShipperId { get; set; }
        public int Quantity { get; set; }




    }
}
