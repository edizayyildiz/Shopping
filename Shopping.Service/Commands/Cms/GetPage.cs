using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Read, "Bir sayfa getirir.")]
    public class GetPage : Command
    {
        public string Id { get; set; }
    }
}
