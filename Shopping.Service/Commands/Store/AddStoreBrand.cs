using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Store, Authorities.Create, "Yeni mağaza markası oluşturur.")]
    public class AddStoreBrand : Command
    {
        public string StoreId { get; set; }
        public string BrandId { get; set; }


    }
}
