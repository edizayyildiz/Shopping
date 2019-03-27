using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Create, "Yeni dilek oluşturur.")]
    public class AddWishlist : Command
    {
        public string UserName { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
