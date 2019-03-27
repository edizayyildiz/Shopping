using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Update, "Dilek güncellendi.")]
    public class EditWishlist : Command
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
