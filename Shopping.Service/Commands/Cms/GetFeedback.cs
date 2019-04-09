using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Read, "Bir geri bildirim getirir.")]
    public class GetFeedback:Command
    {
        public string Id { get; set; }
    }
}
