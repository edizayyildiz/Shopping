using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Bir ürün getirir.")]
    public class GetProduct : Command
    {
        public string Id { get; set; }
    }
}
