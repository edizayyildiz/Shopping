using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Create, "Son Görüntülenen Ürün oluşturur.")]
    public class AddRecentlyDisplayedProduct: Command
    {
        public string ProductId { get; set; }
        public string UserName { get; set; }
        public DateTime DisplayDate { get; set; }
    }
}
