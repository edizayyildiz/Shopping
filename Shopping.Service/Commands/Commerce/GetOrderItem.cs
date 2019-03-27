using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Bir sipariş öğesi getirir.")]
    public class GetOrderItem : Command
    {
        public string Id { get; set; }
    }
}
