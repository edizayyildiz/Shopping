using Shopping.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Update, "Ürün rengi güncellendi.")]
    public class EditProductColor : Command
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ColorId { get; set; }

    }
}
