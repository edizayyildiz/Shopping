using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Update, "Geri Bildirim güncellendi.")]
    public class EditFeedback:Command
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
