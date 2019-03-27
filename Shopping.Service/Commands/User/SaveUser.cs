using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.User, Authorities.Create, "Kullanıcı kayıt etmek.")]
    public class SaveUser : Command
    {
        public Guid? Uid { get; set; }
        public string Name { get; set; }
        public bool IsUser { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string EMail { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public Guid OrganizationUid { get; set; }
        public Guid RoleUid { get; set; }
    }
}
