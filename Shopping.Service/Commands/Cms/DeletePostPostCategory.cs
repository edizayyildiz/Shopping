using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Delete, "Posta ile posta arasındaki ilişki silindi.")]
    public class DeletePostPostCategory : Command
    {
        public string Id { get; set; }

    }
}
