using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Update, "Şehir günceller.")]
    public class EditCity : Command
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }

    }
}
