using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Sepeti getirir.")]
    public class GetCart : Command
    {
        public string Id { get; set; }
    }
}
