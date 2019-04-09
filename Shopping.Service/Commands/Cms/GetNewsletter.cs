using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Read, "Bir abone getirir.")]
    public class GetNewsletter:Command
    {
        public string Id { get; set; }
    }
}
