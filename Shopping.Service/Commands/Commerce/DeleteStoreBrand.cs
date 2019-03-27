using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Delete, "Mağaza Markası silindi.")]
    public class DeleteStoreBrand : Command
    {
        public string Id { get; set; }

    }
}
