using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Update, "Sepetteki ürünü günceller.")]
    public class EditCartItem : Command
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
