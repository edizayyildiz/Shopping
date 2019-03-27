using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Bir sipariş detayı getirir.")]
    public class GetMyOrder : Command
    {
        public string Id { get; set; }
    }
}
