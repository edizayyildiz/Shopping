using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{

    [Describe(CommandType.Cms, Authorities.Create, "Yeni kaydırıcı oluşturur.")]
    public class AddSlider : Command
    {
        public string Name { get; set; }

    }
}
