using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Setting, Authorities.Create, "Yeni dil oluşturur.")]
    public class AddLanguage : Command
    {
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string Flag { get; set; }

    }
}