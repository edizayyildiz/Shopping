using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands

{
    [Describe(CommandType.Cms, Authorities.Delete, "Posta silindi.")]
    public class DeletePost : Command
    {
        public string Id { get; set; }

    }
}
