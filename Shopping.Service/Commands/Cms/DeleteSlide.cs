using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Delete, "Slayt silindi.")]
    public class DeleteSlide : Command
    {
        public string Id { get; set; }

    }
}
