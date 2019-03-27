using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Delete, "Kaydırıcı silindi.")]
    public class DeleteSlider : Command
    {
        public string Id { get; set; }

    }
}
