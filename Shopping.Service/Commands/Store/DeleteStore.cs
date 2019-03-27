using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Store, Authorities.Delete, "Mağaza silindi.")]
    public class DeleteStore : Command
    {
        public string Id { get; set; }

    }
}
