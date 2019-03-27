using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Delete, "Ülke silindi.")]
    public class DeleteCountry : Command
    {
        public string Id { get; set; }

    }
}
