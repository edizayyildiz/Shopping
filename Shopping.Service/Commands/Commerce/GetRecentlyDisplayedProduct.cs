using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Bir son görüntülenen ürün getirir.")]
    public class GetRecentlyDisplayedProduct:Command
    {
        public string Id { get; set; }
    }
}
