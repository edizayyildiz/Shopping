using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.User, Authorities.Read, "Kullanıcı login olur.")]
    public class Login : Command
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
