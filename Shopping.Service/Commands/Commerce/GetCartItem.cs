using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Sepet ürünlerini getirir.")]
    public class GetCartItem : Command
    {
        public string CartId { get; set; }
        public string Id { get; set; }
    }
}
