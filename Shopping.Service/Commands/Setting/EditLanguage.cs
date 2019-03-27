using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Setting, Authorities.Update, "Dil güncellendi.")]
    public class EditLanguage : Command
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string Flag { get; set; }

    }
}
