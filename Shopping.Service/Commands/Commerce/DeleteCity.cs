using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Delete, "Şehir silindi.")]
    public class DeleteCity : Command
    {
        public string Id { get; set; }

    }
}
