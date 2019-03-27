using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.User, Authorities.Read, "Token aktif mi.")]
    public class Verify : Command
    {
    }
}
