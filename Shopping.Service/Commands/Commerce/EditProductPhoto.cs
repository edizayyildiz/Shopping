using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Update, "Ürün resmi güncellendi.")]
    public class EditProductPhoto : Command
    {
        public string Id { get; set; }
        public string Medium { get; set; }
        public string Small { get; set; }
        public string Large { get; set; }
        public string Alt { get; set; }
        public string ProductId { get; set; }

    }
}
