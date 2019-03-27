using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Update, "Sipariş öğesi güncellendi.")]
    public class EditOrderItem : Command
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public string ShipperId { get; set; }
        public int Quantity { get; set; }

    }
}
