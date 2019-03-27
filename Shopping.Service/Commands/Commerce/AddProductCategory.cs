using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Create, "Yeni Ürün Kategorisi oluşturur.")]
    public class AddProductCategory : Command
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string ParentId { get; set; }
    }
}
