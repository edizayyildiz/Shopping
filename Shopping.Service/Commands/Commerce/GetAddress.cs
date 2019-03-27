using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Bir adres getirir.")]
    public class GetAddress : Command
    {
        public string Id { get; set; }
    }
}
