using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Update, "İlçe günceller.")]
    public class EditDistrict : Command
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CityId { get; set; }

    }
}
