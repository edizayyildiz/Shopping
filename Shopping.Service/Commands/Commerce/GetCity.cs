using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Bir þehir getirir.")]
    public class GetCity : Command
    {
        public string Id { get; set; }
    }
}
