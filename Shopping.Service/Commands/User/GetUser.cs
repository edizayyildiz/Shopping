using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.User, Authorities.Read, "Kullanıcı bilgilerini getirir.")]
    public class GetUser : Command
    {
        public Guid Uid { get; set; }
    }
}
