using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Delete, "Sayfa silindi.")]
    public class DeletePage : Command
    {
        public string Id { get; set; }

    }
}
