using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.System, Authorities.Read, "Modül Listesi")]
    public class GetModules : Command
    {
    }
}
