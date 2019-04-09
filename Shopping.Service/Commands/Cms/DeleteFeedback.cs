using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Delete, "Geri Bildirim Silindi.")]
    public class DeleteFeedback:Command
    {
        public string Id { get; set; }
    }
}
