using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.System, Authorities.Create, "Rol Yetkisi ekler")]
    public class AddRoleAuthority : Command
    {
        public Guid RoleUid { get; set; }
        public Guid ModuleAuthUid { get; set; }
    }
}
