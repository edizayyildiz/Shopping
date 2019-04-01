using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Delete, "Sepet siler.")]
    public class DeleteCart : Command
    {
        public string Id { get; set; }
    }
}
