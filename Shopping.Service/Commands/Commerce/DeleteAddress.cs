using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Delete, "Adres silindi.")]
    public class DeleteAddress : Command
    {
        public string Id { get; set; }

    }
}
