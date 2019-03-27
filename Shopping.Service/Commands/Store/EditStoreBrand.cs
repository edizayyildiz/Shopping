using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Update, "Mağaza markasını günceller.")]
    public class EditStoreBrand : Command
    {
        public string Id { get; set; }
        public string StoreId { get; set; }
        public string BrandId { get; set; }

    }
}
