using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Delete, "Abone silindi.")]
   public class DeleteNewsletter:Command
    {
        public string Id { get; set; }
    }
}
