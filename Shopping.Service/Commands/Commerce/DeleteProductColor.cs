using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Delete, "Ürün rengi silindi.")]
    public class DeleteProductColor : Command
    {
        public string Id { get; set; }

    }
}
