using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.User, Authorities.Read, "Üye olmayı sağlar.")]
    public class Register : Command
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Aggree { get; set; }
    }
}
