using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.System, Authorities.Read, "Rol Yetkileri")]
    public class GetRoleAuthorities : Command
    {
        public Guid RoleUid { get; set; }
        public Guid? ModuleUid { get; set; }
    }
}
