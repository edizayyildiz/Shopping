using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.User, Authorities.Create, "Kullanıcı şifresi değiştirir.")]
    public class ChangePassword : Command
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
