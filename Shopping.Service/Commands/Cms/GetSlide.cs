using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Read, "Bir slayt getirir.")]
    public class GetSlide : Command
    {
        public string Id { get; set; }
    }
}
