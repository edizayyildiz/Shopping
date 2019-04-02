using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Create, "Yeni sepet oluşturur.")]
    public class AddCart : Command
    {
        public string UserName { get; set; }
    }
}
