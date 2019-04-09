using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Create, "Yeni Geri Bildirim Oluştur.")]
    public class AddFeedback:Command
    {

        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string Subject { get; set; }
       
        public string Message { get; set; }
    }
}
