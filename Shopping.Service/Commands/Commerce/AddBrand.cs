using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Create, "Yeni marka oluşturur.")]
    public class AddBrand : Command
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public bool ShowInHome { get; set; }
        public bool IsActive { get; set; }
    }
}
