using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.User, Authorities.Read, "Çıkış yapar.")]
    public class Logout : Command
    {
    }
}
