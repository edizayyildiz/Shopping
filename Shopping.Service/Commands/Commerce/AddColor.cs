using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Create, "Yeni renk oluşturur.")]
    public class AddColor : Command
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
