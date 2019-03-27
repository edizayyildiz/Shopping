using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Update, "Kargo firması güncellendi.")]
    public class EditShipper : Command
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

    }
}
