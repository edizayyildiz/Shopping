using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
        [Describe(CommandType.Commerce, Authorities.Update, "Marka günceller.")]
        public class EditBrand : Command
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Slug { get; set; }
            public string Image { get; set; }
            public bool ShowInHome { get; set; }
            public bool IsActive { get; set; }
        }
 }
