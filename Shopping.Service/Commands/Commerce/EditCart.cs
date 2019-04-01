using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Update, "Sepeti günceller.")]
    public class EditCart : Command
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}
